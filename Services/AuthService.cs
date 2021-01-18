using HR.Helpers;
using HumanResource.Api.Helpers;
using HumanResource.Api.Options;
using HumanResource.ApplicationCore.Interfaces;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using HumanResource.ApplicationCore.Entities;
using System.Threading.Tasks;
using HumanResource.Api.DTOS.Responses;
using HumanResource.Api.DTOS.Requests;
using System.Linq.Expressions;
using HumanResource.ApplicationCore.Specifications;
using MimeKit;
using MimeKit.Utils;
using MailKit.Net.Smtp;
using IThong.Entities;

namespace HumanResource.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        #region Ịnjectors

        private readonly JwtSettings _JwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly Cryptography _cryptography;
        private readonly IUnitOfWork _unitOfWork;


        #endregion
        #region Constructors
        public AuthService(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, Cryptography cryptography, IUnitOfWork unitOfWork)
        {
            _JwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _cryptography = cryptography;
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Functions
        /// <summary>
        /// check and validate token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;

                }
                return principal;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// validate secerity SecurityToken
        /// </summary>
        /// <param name="validatedToken"></param>
        /// <returns></returns>
        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                    jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// generate token 
        /// </summary>
        /// <param name="emp">employee</param>
        /// <param name="tokenRefreshBind">reference refresh-token</param>
        /// <param name="registerCheck"></param>
        /// <returns></returns>
        private  string GenerateToken(User emp,out string tokenRefreshBind,  bool registerCheck = true)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JwtSettings.Secret);
            var claims = new List<Claim> {
                        new Claim(Constant.CustomClaims.EMAIL, emp.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(Constant.CustomClaims.USERNAME, emp.Username),
                        new Claim(Constant.CustomClaims.ROLE,emp.RoleId!=0 ? emp.RoleId.ToString():""),
                        new Claim(Constant.CustomClaims.USERID,emp.Id.ToString())
                    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_JwtSettings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserID = emp.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                Token = Guid.NewGuid().ToString()
            };
            tokenRefreshBind = refreshToken.Token;
            if (!registerCheck)
            {
                 _unitOfWork.Repository<RefreshToken>().Add(refreshToken);
            }
            else
            {
                emp.RefreshTokens = new List<RefreshToken> { refreshToken};
                 _unitOfWork.Repository<User>().Add(emp);
            }
            return tokenHandler.WriteToken(token);
        }


        #endregion
        #region Implement Interface
        /// <summary>
        /// register employee into system
        /// </summary>
        /// <param name="empRequest"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthResult> RegisterAsync(UserRequest empRequest)
        {
            // create hash and salt 
            var salt = _cryptography.GennerateSalt();
            var hash = _cryptography.CreateHash(empRequest.Password, salt);
            var emp = new User
            {
                Email=empRequest.Email,
                DateOfBirth=empRequest.DateOfBirth,
                DateCreateNewPassword=DateTime.Now,
                Username=empRequest.Username,
                IsActive=true,
                RoleId=empRequest.RoleId.GetValueOrDefault()==0? 3: empRequest.RoleId.GetValueOrDefault(),
                CitizenShipProfile=new CitizenShipProfile {
                    FirstName=empRequest.FirstName,
                    LastName=empRequest.LastName,
                    DateOfBirth=empRequest.DateOfBirth,
                    PhoneNumber=empRequest.PhoneNumber,
                    Addresses=empRequest.Addresses
                }

            };
            emp.PasswordSalt = salt;
            emp.PasswordHash = hash;
            // generate token
            var accessToken=  GenerateToken(emp, out string RefreshToken);
            if(await _unitOfWork.Complete() > 0)
            {
                return new AuthResponseSuccess {
                    AccessToken = accessToken,
                    Email = empRequest.Email,
                    Username = empRequest.Username,
                    RefreshToken = RefreshToken
                };
            }
            return null;
        }
        /// <summary>
        /// User Login into system
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public async Task<AuthResult> Login(LoginRequest loginRequest)
        {
            // find employee match username or email
            Expression<Func<User, bool>> filter = emp => emp.Email == loginRequest.User || emp.Username==loginRequest.User;
            var entity= await _unitOfWork.Repository<User>().FirstOrDefaultAsync(new BaseSpecification<User>(filter));
            // username or email is invalid
            if (entity == null || entity?.IsActive==false)
            {
                return null;
            }
            else
            {
                if(_cryptography.Validate(loginRequest.Password, entity.PasswordSalt, entity.PasswordHash))
                {
                    // generate token
                    var accessToken = GenerateToken(entity, out string RefreshToken,false);
                    if (await _unitOfWork.Complete() > 0)
                    {
                        return new AuthResponseSuccess
                        {
                            Id=entity.Id,
                            AccessToken = accessToken,
                            Email = entity.Email,
                            Username = entity.Username,
                            RefreshToken = RefreshToken
                        };
                    }

                }
            }
            return null;
        }
        /// <summary>
        /// User will get token when token expried
        /// </summary>
        /// <param name="refreshTokenRequest"></param>
        /// <returns></returns>
        public async Task<AuthResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            // validate token
            var validatedToken = GetPrincipalFromToken(refreshTokenRequest.Token);
            if (validatedToken == null)
            {
                return new AuthResponseFail
                {
                    Errors = new [] { "Invalid token" }
                };
            }

            // check token have expiry
            var expiryDateunix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                                       .AddSeconds(expiryDateunix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthResponseFail { Errors = new[] { "This token hasn't expired yet" } };
            }
            // 
            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            Expression<Func<RefreshToken, bool>> filterRefreshToken = rf => rf.Token == refreshTokenRequest.RefreshToken;
            var specifications = new BaseSpecification<RefreshToken>(filterRefreshToken);
            specifications.AddIncluded(rf => rf.User);
            var storedRefreshToken = await _unitOfWork.Repository<RefreshToken>().FirstOrDefaultAsync(specifications);
            // token not exits
            if (storedRefreshToken == null)
            {
                return new AuthResponseFail { Errors = new[] { "This Refreshtoken not exist" } };
            }
            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthResponseFail { Errors = new[] { "This refresh token has expired" } };
            }
            if (storedRefreshToken.Invalidated)
            {
                return new AuthResponseFail { Errors = new[] { "This refresh token has been invalidated" } };
            }
            if (storedRefreshToken.Used)
            {
                return new AuthResponseFail { Errors = new[] { "This refresh token has been Used" } };
            }
            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthResponseFail { Errors = new[] { "This refresh token dose  not match JWT" } };
            }
            // update refreshtoken after it's used
            storedRefreshToken.Used = true;
            _unitOfWork.Repository<RefreshToken>().Update(storedRefreshToken);
            var accessToken = GenerateToken(storedRefreshToken.User, out string RefreshToken, false);
            if (await _unitOfWork.Complete() > 0)
            {
                return new AuthResponseSuccess
                {
                    Id= storedRefreshToken.User.Id,
                    AccessToken = accessToken,
                    Email = storedRefreshToken.User.Email,
                    Username = storedRefreshToken.User.Username,
                    RefreshToken = RefreshToken
                };
            }
            return null;
           
        }
        /// <summary>
        /// Reset password: new password will send to email of employee
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public async Task<bool> ResetPassword(string email)
        {
            var baseSpecification = new BaseSpecification<User>(emp => emp.Email == email);
            Expression<Func<User, object>> include = user => user.CitizenShipProfile;
            baseSpecification.AddIncluded(include);
            // find employee
            var employee = await  _unitOfWork.Repository<User>().SingleOrDefaultAsync(baseSpecification);
            // throw exception if not found employee
            if (employee == null)
                throw new ArgumentNullException("Gmail does not exist in the system");
            // create new password
            var newPassword = PasswordGenerator.RandomPassword(8);
            //create message
            var message = new MimeMessage();
            // add property for messsage
            message.From.Add(new MailboxAddress(Constant.ProfileMail.SENDERNAME, Constant.ProfileMail.SENDEROFMAIL));
            message.To.Add(new MailboxAddress(employee.CitizenShipProfile.FirstName+" "+employee.CitizenShipProfile.LastName, employee.Email));
            message.Subject = Constant.ProfileMail.SUBJECT;
            
            BodyBuilder bodyBuilder = new BodyBuilder();
            // add contentId of image local into mail server
            var image = bodyBuilder.LinkedResources.Add(Constant.ProfileMail.URLIMAGELOGO);
            image.ContentId = MimeUtils.GenerateMessageId();
            bodyBuilder.HtmlBody = string.Format(BodyMessage.MessBodyEmail(employee, newPassword), image.ContentId);
            message.Body = bodyBuilder.ToMessageBody();
            // edit employee
            employee.PasswordSalt = _cryptography.GennerateSalt();
            employee.PasswordHash = _cryptography.CreateHash(newPassword, employee.PasswordSalt);
            employee.DateCreateNewPassword = DateTime.Now;
            
            if (await _unitOfWork.Complete() > 0)
            {
                // send email if change success
                using (var client = new SmtpClient())
                {
                    client.Connect(Constant.ProfileMail.HOSTEMAIL, Constant.ProfileMail.PORTEMAIL, false);
                    client.Authenticate(Constant.ProfileMail.SENDEROFMAIL, Constant.ProfileMail.SENDERPW);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            else
            {
                return false;
            }
           
           
        }

        #endregion

    }
}

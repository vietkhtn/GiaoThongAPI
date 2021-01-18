using HumanResource.Api.DTOS.Requests;
using HumanResource.Api.DTOS.Responses;
using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.ApplicationCore.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(UserRequest emp);
        Task<AuthResult> Login(LoginRequest loginRequest);
        Task<AuthResult> RefreshToken(RefreshTokenRequest refreshTokenRequest);
        Task<bool> ResetPassword(string email);
    }
}

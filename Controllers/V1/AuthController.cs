using AutoMapper;
using HumanResource.Api.DTOS.Requests;
using HumanResource.Api.DTOS.Responses;
using HumanResource.Api.Routes;
using HumanResource.ApplicationCore.Entities;
using HumanResource.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.Controllers.V1
{
    public class AuthController : Controller
    {
        #region injectors
        private readonly IAuthService _authService;
        private readonly IMapper _map;
        #endregion
        #region Constructors
        public AuthController(IAuthService authService, IMapper map)
        {
            _authService = authService;
            _map = map;
        }
        #endregion
        #region main
        /// <summary>
        /// Register employee
        /// </summary>
        /// <param name="employeeRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] UserRequest employeeRequest)
        {
          //  var emp = _map.Map<User>(employeeRequest);
            var rs = await _authService.RegisterAsync(employeeRequest);
            if (rs == null)
            {
                return BadRequest();
            }
            return Ok(rs);
        }
        /// <summary>
        /// Login into system
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var rs = await _authService.Login(loginRequest); 
            if (rs == null)
            {
                return BadRequest();
            }
            return Ok(rs);
        }
        /// <summary>
        /// Refresh-token
        /// </summary>
        /// <param name="refreshTokenRequest"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Auth.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var rs = await _authService.RefreshToken(refreshTokenRequest);
            if(rs==null || rs is AuthResponseFail)
            {
                return BadRequest(rs);
            }
            return Ok(rs);
        }
        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Auth.ResetPassword)]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var rs = await _authService.ResetPassword(email);
            if (rs)
            {
                return NoContent();
            }
            return BadRequest();
            
        }
        #endregion
    }
}

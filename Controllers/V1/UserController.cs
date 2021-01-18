using AutoMapper;
using HumanResource.Api.Routes;
using IThong.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UserController:Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _map;
        public UserController(IUserService userService,IMapper mapper)
        {
            _map = mapper;
            _userService = userService;

        }
        [HttpGet(ApiRoutes.User.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _userService.GetAll();
            return Ok(rs);
        }

    }
}

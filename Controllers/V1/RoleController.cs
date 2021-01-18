using AutoMapper;
using HR.Helpers;
using HumanResource.Api.Routes;
using IThong.DTOS.Responses;
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
    public class RoleController:Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _map;
        public RoleController(IRoleService roleService,IMapper mapper)
        {
            _roleService = roleService;
            _map = mapper;

        }

        [HttpGet(ApiRoutes.Role.GetAll)]
        public async Task<IActionResult> GetRole()
        {
            var rs = await _roleService.GetAllAsync();
            return Ok(_map.Map<List<RoleResponse>>(rs));
        }
    }
}

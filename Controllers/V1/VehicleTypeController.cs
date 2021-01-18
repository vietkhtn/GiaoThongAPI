using AutoMapper;
using HumanResource.Api.Routes;
using IThong.DTOS.Responses;
using IThong.Interfaces;
using IThong.Services;
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

    public class VehicleTypeController:Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IMapper _map;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService,IMapper map)
        {
            _vehicleTypeService = vehicleTypeService;
            _map = map;

        }
        [HttpGet(ApiRoutes.VehicleType.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_map.Map<IEnumerable< VehicleTypeDTO >>( await _vehicleTypeService.GetAll()));
        }
    }
}

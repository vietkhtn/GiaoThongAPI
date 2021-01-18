using AutoMapper;
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
using IThong.DTOS.Requests;
using IThong.Entities;
using HR.Helpers;

namespace IThong.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class VehicleController: Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _map;
        public VehicleController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _map = mapper;
        }
        [HttpGet(ApiRoutes.Vehicle.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _vehicleService.GetAll();
            return Ok(_map.Map<IEnumerable<VehicleDTO>>(rs));

        }
        [HttpGet(ApiRoutes.Vehicle.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] int Id)
        {
            var rs = await _vehicleService.GetOne(Id);
            if (rs == null)
            {
                return NoContent();
            }
            return Ok(_map.Map<VehicleDTO>(rs));
        }
        
        [HttpPost(ApiRoutes.Vehicle.Create)]
        [Authorize(Policy =Constant.RolePolicy.NHANVIEN)]
        public async Task<IActionResult> Create([FromBody] VehicleCreateRequest vehicleCreateRequest)
        {
            var rs = await _vehicleService.Create(_map.Map<Vehicle>(vehicleCreateRequest));
            if (rs == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetOne),new { Id=rs.Id},_map.Map<VehicleDTO>(rs));

        }
        [HttpPut(ApiRoutes.Vehicle.Update)]
        [Authorize(Policy = Constant.RolePolicy.NHANVIEN)]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] VehicleUpdate vehicleUpdate)
        {
            var rs = await _vehicleService.Update(Id, vehicleUpdate);
            if (!rs)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

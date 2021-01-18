using AutoMapper;
using HumanResource.Api.Routes;
using IThong.DTOS.Responses;
using IThong.Entities;
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
    public class DriversLicensesTypeController:Controller
    {
        private readonly IDriversLicensesTypeService _driversLicensesTypeService;
        private readonly IMapper _map;
        public DriversLicensesTypeController(IDriversLicensesTypeService driversLicensesTypeService,IMapper map)
        {
            _driversLicensesTypeService = driversLicensesTypeService;
            _map = map;

        }
        [HttpGet(ApiRoutes.DriversLicensesType.GetAll)]
        public async Task<IActionResult> GetAll()
        {
             return Ok(_map.Map<IEnumerable<DriversLicensesTypeDTO>>(await _driversLicensesTypeService.GetAll()));
          //  return Ok(await _driversLicensesTypeService.GetAll());
          
        }
        [HttpGet(ApiRoutes.DriversLicensesType.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] int Id)
        {
            return Ok (_map.Map<DriversLicensesTypeDTO>(await _driversLicensesTypeService.GetOne(Id)));

        }
    }
}

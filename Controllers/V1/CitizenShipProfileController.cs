using AutoMapper;
using HumanResource.Api.Routes;
using IThong.DTOS.Requests;
using IThong.DTOS.Responses;
using IThong.Entities;
using IThong.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IThong.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CitizenShipProfileController:Controller
    {
        private readonly ICitizenShipProfileService _citizenShipProfileService;
        private readonly IMapper _map;
        public CitizenShipProfileController(ICitizenShipProfileService citizenShipProfileService,IMapper mapper)
        {
            _citizenShipProfileService = citizenShipProfileService;
            _map = mapper;

        }
        [HttpGet(ApiRoutes.CitizenShipProfile.GetAll)]
        public async Task<IActionResult> GetAll() {
            var rs= await _citizenShipProfileService.GetAll();
            return Ok(_map.Map<IEnumerable<CitizenShipProfileDTO>>(rs));
        }
        [HttpGet(ApiRoutes.CitizenShipProfile.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] int Id)
        {
            var rs = await _citizenShipProfileService.GetOne(Id);
            if (rs==null)
            {
                return NotFound();
            }
            return Ok(_map.Map<CitizenShipProfileDTO>(rs));
           
        }
        [HttpDelete(ApiRoutes.CitizenShipProfile.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var rs = await _citizenShipProfileService.Delete(Id);
            if (!rs)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut(ApiRoutes.CitizenShipProfile.Delete)]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] CitizenShipProfileUpdateRequest citizenShipProfileUpdateRequest)
        {
            var rs = await _citizenShipProfileService.Update(Id, citizenShipProfileUpdateRequest);
            if (!rs)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPost(ApiRoutes.CitizenShipProfile.Create)]
        public async Task<IActionResult> Created([FromBody] CitizenShipProfileCreateRequest citizenShipProfileCreateRequest)
        {
            var rs = await _citizenShipProfileService.Create(_map.Map< CitizenShipProfile>(citizenShipProfileCreateRequest));
            if (rs == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetOne), new { Id = rs.Id }, _map.Map<CitizenShipProfileDTO>(rs));
        }

    }
}

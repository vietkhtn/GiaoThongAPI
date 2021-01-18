using AutoMapper;
using HR.Helpers;
using HumanResource.Api.Routes;
using IThong.DTOS.Requests;
using IThong.DTOS.Responses;
using IThong.Extentions;
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
    public class RecordProfileController:Controller
    {
        private readonly IRecordProfileService _recordProfileService;
        private readonly IMapper _map;
        public RecordProfileController(IRecordProfileService recordProfileService,IMapper map)
        {
            _recordProfileService = recordProfileService;
            _map = map;

        }
        [HttpGet(ApiRoutes.RecordProfile.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_map.Map<IEnumerable<RecordProfileDTO>>(await _recordProfileService.GetAll()));

        }
        [HttpGet(ApiRoutes.RecordProfile.GetOne)]
        public async Task<IActionResult> GetOne([FromRoute] int Id)
        {
            return Ok(_map.Map<RecordProfileDTO>(await _recordProfileService.GetOne(Id)));
        //    return Ok(await _recordProfileService.GetOne(Id));

        }
        [HttpDelete(ApiRoutes.RecordProfile.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var rs = await _recordProfileService.Delete(Id);
            if (rs)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet(ApiRoutes.RecordProfile.Approval)]
        public async Task<IActionResult> Approval([FromRoute] int Id)
        {
            var rs = await _recordProfileService.Approval(Id);
            if (!rs)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPut(ApiRoutes.RecordProfile.Update)]
        public async Task<IActionResult> Updated( [FromRoute] int Id,[FromBody]RecordProfileUpdateRequest recordProfileUpdateRequest)
        {
            var userIdText= HttpContext.GetClaim(Constant.CustomClaims.USERID);
            Int32.TryParse(userIdText, out int userId);
            if (userId == 0)
            {
                return BadRequest();

            }

            var rs =await _recordProfileService.Update(Id, userId, recordProfileUpdateRequest);
            if (!rs)
            {
                return BadRequest();

            }
            return NoContent();

        }
        [HttpPost(ApiRoutes.RecordProfile.RegisterVehicle)]
        public async Task<IActionResult> RegisterVehilce([FromBody] RegisterVehicleRequest registerVehicleRequest)
        {

            var userIdText = HttpContext.GetClaim(Constant.CustomClaims.USERID);
            Int32.TryParse(userIdText, out int userId);
            if (userId == 0)
            {
                return BadRequest();

            }

            var rs = await _recordProfileService.RegisterVehicle(registerVehicleRequest, userId);
            if (!rs)
            {
                return BadRequest();

            }
            return NoContent();
        }
    }
}

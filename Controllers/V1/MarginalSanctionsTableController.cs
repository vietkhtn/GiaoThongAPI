using AutoMapper;
using HumanResource.Api.Routes;
using IThong.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IThong.DTOS.Requests;
using IThong.Entities;
using IThong.Extentions;
using HR.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IThong.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MarginalSanctionsTableController: Controller
    {
        private readonly IMarginalSanctionsTableService _marginalSanctionsTableService;
        private readonly IMapper _map;
        public MarginalSanctionsTableController(IMarginalSanctionsTableService marginalSanctionsTableService,IMapper mapper)
        {
            _marginalSanctionsTableService = marginalSanctionsTableService;
            _map = mapper;

        }
        [HttpPost(ApiRoutes.MarginalSanctionsTable.Create)]
    //    [Authorize(Policy =Constant.RolePolicy.CANBO)]
        public async Task<IActionResult> Create([FromBody] MarginalSanctionsTableCreate marginalSanctionsTableCreate)
        {
            var userIdText = HttpContext.GetClaim(Constant.CustomClaims.USERID);
            Int32.TryParse(userIdText, out int userId);
            if (userId == 0)
            {
                return BadRequest();

            }
            var entity = _map.Map<MarginalSanctionsTable>(marginalSanctionsTableCreate);
            entity.UserHandleerId = userId;
            var rs = await _marginalSanctionsTableService.Create(entity);
            if (!rs)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

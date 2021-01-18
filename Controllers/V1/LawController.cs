using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HumanResource.Api.Routes;
using HumanResource.ApplicationCore.Entities;
using IThong.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IThong.Controllers.V1
{
    public class LawController : Controller
    {
        private readonly ILawService _lawService;

        public LawController(ILawService lawService)
        {
            _lawService = lawService;
        }

        [HttpGet(ApiRoutes.Law.GetAll)]
        public async Task<IActionResult> GetLaws([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await _lawService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Law.GetOne)]
        public async Task<IActionResult> GetLawById([FromRoute] int lawid)
        {
            var result = await _lawService.GetOneAsync(lawid);
            return Ok(result);
        }
        
        [HttpGet(ApiRoutes.Law.FindLaw)]
        public async Task<IActionResult> FindLaw([FromQuery] string diem, [FromQuery] string noidungdieuluat)
        {
            try
            {
                var result = await _lawService.FindLaw(noidungdieuluat, diem);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}
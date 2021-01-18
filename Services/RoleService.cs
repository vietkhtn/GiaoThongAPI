using AutoMapper;
using HumanResource.ApplicationCore.Entities;
using HumanResource.ApplicationCore.Interfaces;
using IThong.DTOS.Responses;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
             return await _unitOfWork.Repository<Role>().ListAllAsync();
        }
    }
}

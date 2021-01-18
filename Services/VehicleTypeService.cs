using HumanResource.ApplicationCore.Interfaces;
using IThong.Entities;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork _unit;
        public VehicleTypeService(IUnitOfWork unit)
        {
            _unit = unit;

        }
        public async Task<IEnumerable<VehicleType>> GetAll()
        {
            return await _unit.Repository<VehicleType>().ListAllAsync();
        }
    }
}

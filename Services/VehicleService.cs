using HumanResource.ApplicationCore.Interfaces;
using IThong.DTOS.Requests;
using IThong.Entities;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unit;
        public VehicleService(IUnitOfWork unit)
        {
            _unit = unit;

        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
             await _unit.Repository<Vehicle>().AddAsync(vehicle);
            return await _unit.Complete() > 0 ? vehicle : null;
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _unit.Repository<Vehicle>().ListAllAsync();
        }

        public async Task<Vehicle> GetOne(int Id)
        {
            return await _unit.Repository<Vehicle>().GetByIdAsync(Id);
            
        }

        public async Task<bool> Update(int Id,VehicleUpdate vehicleUpdate)
        {
            var entry = await GetOne(Id);
            if (entry == null)
            {
                return false;
            }
            if(vehicleUpdate.IsActive!=null)
            {
                entry.IsActive = vehicleUpdate.IsActive.GetValueOrDefault();
            }
            if (!String.IsNullOrWhiteSpace(vehicleUpdate.NumberPlate))
            {
                entry.NumberPlate = vehicleUpdate.NumberPlate;
            }
            _unit.Repository<Vehicle>().Update(entry);
            return await _unit.Complete() > 0;
        }
    }
}

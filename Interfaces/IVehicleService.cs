using IThong.DTOS.Requests;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAll();
        Task<Vehicle> GetOne(int Id);

        Task<Vehicle> Create(Vehicle vehicle);
        Task<bool> Update(int Id,VehicleUpdate vehicleUpdate);

    }
}

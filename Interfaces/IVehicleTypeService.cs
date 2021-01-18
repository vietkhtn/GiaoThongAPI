using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetAll();
    }
}

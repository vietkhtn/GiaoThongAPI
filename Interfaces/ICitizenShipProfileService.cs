using IThong.DTOS.Requests;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface ICitizenShipProfileService
    {
        Task<IEnumerable<CitizenShipProfile>> GetAll();
        Task<CitizenShipProfile> GetOne(int Id);
        Task<bool> Delete(int Id);
        Task<bool> Update(int Id, CitizenShipProfileUpdateRequest citizenShipProfileUpdateRequest);
        Task<CitizenShipProfile> Create(CitizenShipProfile citizenShipProfile);
    }
}

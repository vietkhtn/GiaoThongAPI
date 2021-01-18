using IThong.DTOS.Requests;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IRecordProfileService
    {
        Task<IEnumerable<RecordProfile>> GetAll();
        Task<RecordProfile> GetOne(int Id);
        Task<bool> Delete(int Id);

        Task<bool> Approval(int Id);
        Task<bool> Update(int recordProfileId, int UserIdUpdate, RecordProfileUpdateRequest recordProfileUpdateRequest);
        Task<bool> RegisterVehicle(RegisterVehicleRequest registerVehicleRequest, int UserIdUpdate);


    }
}

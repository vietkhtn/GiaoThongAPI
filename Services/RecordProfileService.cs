using HumanResource.ApplicationCore.Interfaces;
using HumanResource.ApplicationCore.Specifications;
using IThong.DTOS.Requests;
using IThong.Entities;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class RecordProfileService : IRecordProfileService
    {
        private readonly IUnitOfWork _unit;
        public RecordProfileService(IUnitOfWork unit)
        {
            _unit = unit;

        }

        public async Task<bool> Approval(int Id)
        {
            var repoRecord = _unit.Repository<RecordProfile>();
            var entry = await repoRecord.GetByIdAsync(Id);
            if (entry != null && entry?.IsActive==false)
            {
                entry.IsActive = true;
                if(await _unit.Complete() > 0)
                {
                    return true;
                }
                
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            _unit.Repository<RecordProfile>().Delete(Id);
            if( await _unit.Complete() > 0)
            {
                return true;
            }
            return false;
                
        }

        public async Task<IEnumerable<RecordProfile>> GetAll()
        {
            var spec = new BaseSpecification<RecordProfile>();
            List<Expression<Func<RecordProfile, object>>> includeExpressions = new List<Expression<Func<RecordProfile, object>>> { 
                rp=>rp.VehicleOwner,
                rp=>rp.UpdatedUser,
                rp=>rp.Vehicle
            };
            spec.AddIncludedRange(includeExpressions);

            return await _unit.Repository<RecordProfile>().ListAsync(spec);
        }

        public async Task<RecordProfile> GetOne(int Id)
        {
            Expression<Func<RecordProfile, bool>> filter = rp => rp.Id == Id;
            var spec = new BaseSpecification<RecordProfile>(filter);
            List<Expression<Func<RecordProfile, object>>> includeExpressions = new List<Expression<Func<RecordProfile, object>>> {
                rp=>rp.VehicleOwner,
                rp=>rp.UpdatedUser,
                rp=>rp.Vehicle
            };
            spec.AddIncludedRange(includeExpressions);

            return await _unit.Repository<RecordProfile>().SingleOrDefaultAsync(spec);
        }

        public async Task<bool> RegisterVehicle(RegisterVehicleRequest registerVehicleRequest, int UserIdUpdate)
        {
            var entity = new RecordProfile { 
                CreateDate=DateTime.Now,
                IsActive=false,
                Note=null,
                UpdatedDate=DateTime.Now,
                UpdatedUserId=null,
                VehicleOwnerId= UserIdUpdate,
                Vehicle=new Vehicle
                {
                    Brand= registerVehicleRequest.Brand,
                    Color= registerVehicleRequest.Color,
                    FrameNumber= registerVehicleRequest.FrameNumber,
                    IsActive=false,
                    Note= registerVehicleRequest.Note,
                    NumberPlate= registerVehicleRequest.NumberPlate,
                    ProductionDate= registerVehicleRequest.ProductionDate,
                    RegistrationDate= registerVehicleRequest?.RegistrationDate?? DateTime.Now,
                    VehicleTypeId= registerVehicleRequest.VehicleTypeId,
                    Capacity= registerVehicleRequest.Capacity,
                    EngineIDNo= registerVehicleRequest.EngineIDNo
                }
               
            };
            await _unit.Repository<RecordProfile>().AddAsync(entity);
            return await _unit.Complete() > 0;
        }

        public async Task<bool> Update(int recordProfileId, int UserIdUpdate, RecordProfileUpdateRequest recordProfileUpdateRequest)
        {
            var entry= await _unit.Repository<RecordProfile>().GetByIdAsync(recordProfileId);
            if (entry == null)
            {
                return false;
            }
            entry.UpdatedDate = DateTime.Now;
            if (recordProfileUpdateRequest.IsActive != null)
            {
                entry.IsActive = recordProfileUpdateRequest.IsActive.GetValueOrDefault();
            }
            if (recordProfileUpdateRequest.VehicleId != null)
            {
                entry.VehicleId = recordProfileUpdateRequest.VehicleId.GetValueOrDefault();
            }
            if (recordProfileUpdateRequest.VehicleOwnerId != null)
            {
                entry.VehicleOwnerId = recordProfileUpdateRequest.VehicleOwnerId.GetValueOrDefault();

            }
            if (!string.IsNullOrWhiteSpace(recordProfileUpdateRequest.Note))
            {
                entry.Note = recordProfileUpdateRequest.Note;
            }

            entry.UpdatedUserId = UserIdUpdate;

            _unit.Repository<RecordProfile>().Update(entry);
            return await _unit.Complete() > 0;
        }
    }
}

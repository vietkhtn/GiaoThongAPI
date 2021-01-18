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
    public class CitizenShipProfileService : ICitizenShipProfileService
    {
        private readonly IUnitOfWork _unit;
        public CitizenShipProfileService(IUnitOfWork unit)
        {
            _unit = unit;

        }

        public async Task<CitizenShipProfile> Create(CitizenShipProfile citizenShipProfile)
        {
            await _unit.Repository<CitizenShipProfile>().AddAsync(citizenShipProfile);
            return await _unit.Complete() > 0 ? citizenShipProfile : null;
        }

        public async Task<bool> Delete(int Id)
        {
            var entity =  await GetOne(Id);
            if (entity == null)
            {
                return false;
            }
            _unit.Repository<CitizenShipProfile>().Delete(entity);
            return await _unit.Complete() > 0;
        }

        public async Task<IEnumerable<CitizenShipProfile>> GetAll()
        {
            return await _unit.Repository<CitizenShipProfile>().ListAllAsync();
        }

        public async Task<CitizenShipProfile> GetOne(int Id)
        {
            return await _unit.Repository<CitizenShipProfile>().GetByIdAsync(Id);
        }

        public async Task<bool> Update(int Id, CitizenShipProfileUpdateRequest citizenShipProfileUpdateRequest)
        {
            var entry = await GetOne(Id);
            if (entry == null)
            {
                return false;
            }
            entry.FirstName = citizenShipProfileUpdateRequest.FirstName;
            entry.LastName = citizenShipProfileUpdateRequest.LastName;
            entry.DateOfBirth = citizenShipProfileUpdateRequest.DateOfBirth;
            entry.PhoneNumber = citizenShipProfileUpdateRequest.PhoneNumber;
            entry.Addresses = citizenShipProfileUpdateRequest.Addresses;
            entry.Gender = citizenShipProfileUpdateRequest.Gender;
            _unit.Repository<CitizenShipProfile>().Update(entry);
            return await _unit.Complete() > 0;
        }
    }
}

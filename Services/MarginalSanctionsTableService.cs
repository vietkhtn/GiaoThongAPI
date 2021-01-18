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
    public class MarginalSanctionsTableService : IMarginalSanctionsTableService
    {
        private readonly IUnitOfWork _unit;
        public MarginalSanctionsTableService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public async Task<bool> Create(MarginalSanctionsTable marginalSanctionsTableCreate)
        {
            await _unit.Repository<MarginalSanctionsTable>().AddAsync(marginalSanctionsTableCreate);
            return await _unit.Complete() > 0;
        }
    }
}

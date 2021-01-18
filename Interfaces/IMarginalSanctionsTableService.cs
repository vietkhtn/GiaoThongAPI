using IThong.DTOS.Requests;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IMarginalSanctionsTableService
    {
        Task<bool> Create(MarginalSanctionsTable marginalSanctionsTableCreate);
    }
}

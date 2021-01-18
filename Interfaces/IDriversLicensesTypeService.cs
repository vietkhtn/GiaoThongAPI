using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IDriversLicensesTypeService
    {
        Task<IEnumerable<DriversLicensesType>> GetAll();
        Task<DriversLicensesType> GetOne(int Id);


    }
}

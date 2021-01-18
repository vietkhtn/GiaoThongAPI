using HumanResource.ApplicationCore.Interfaces;
using HumanResource.ApplicationCore.Specifications;
using IThong.Entities;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class DriversLicensesTypeService : IDriversLicensesTypeService
    {
        private readonly IUnitOfWork _unit;
        public DriversLicensesTypeService(IUnitOfWork unit)
        {
            _unit = unit;

        }
        public async Task<IEnumerable<DriversLicensesType>> GetAll()
        {
            var spec = new BaseSpecification<DriversLicensesType>();
            Expression<Func<DriversLicensesType, object>> includeExpression =dv => dv.VehicleTypeDriversLicenseTypes;
            
            spec.AddIncluded(includeExpression);
            return await _unit.Repository<DriversLicensesType>().ListAsync(spec);
        }

        public async Task<DriversLicensesType> GetOne(int Id)
        {
            Expression<Func<DriversLicensesType, bool>> filter = dl => dl.Id == Id;
            var spec = new BaseSpecification<DriversLicensesType>(filter);
            Expression<Func<DriversLicensesType, object>> includeExpression = dv => dv.VehicleTypeDriversLicenseTypes;

            spec.AddIncluded(includeExpression);
            return await _unit.Repository<DriversLicensesType>().SingleOrDefaultAsync(spec);
        }
    }
}

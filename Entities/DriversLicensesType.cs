using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class DriversLicensesType: BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public virtual ICollection<VehicleTypeDriversLicenseType> VehicleTypeDriversLicenseTypes { get; set; }
        public virtual ICollection<DriversLicense> DriversLicenses  { get; set; }
    }
}

using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class VehicleType:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Fees { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<VehicleTypeDriversLicenseType> VehicleTypeDriversLicenseTypes { get; set; }
    }
}

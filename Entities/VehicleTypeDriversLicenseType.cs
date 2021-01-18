using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class VehicleTypeDriversLicenseType: BaseEntity
    {
        public int VehicleTypeId { get; set; }
        public int DriversLicensesTypeId { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        public virtual VehicleType GetVehicleType { get; set; }
        [ForeignKey(nameof(DriversLicensesTypeId))]
        public virtual DriversLicensesType DriversLicensesType { get; set; }
        public virtual ICollection<DriversLicense> DriversLicenses { get; set; }


    }
}

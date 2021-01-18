using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class DriversLicense: BaseEntity
    {
        public int CitizenShipProfileId { get; set; }
        public int DriversLicensesTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime GrantedDate { get; set; }

        [ForeignKey(nameof(CitizenShipProfileId))]
        public virtual CitizenShipProfile CitizenShipProfile { get; set; }
        [ForeignKey(nameof(DriversLicensesTypeId))]
        public virtual DriversLicensesType DriversLicensesType { get; set; }
    }
}

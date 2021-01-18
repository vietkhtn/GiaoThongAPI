using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class Vehicle:BaseEntity
    {
        public string FrameNumber { get; set; }
        public string Color { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public string Brand { get; set; }
        public int VehicleTypeId { get; set; }
        public bool IsActive { get; set; } = false;
        public string NumberPlate { get; set; }
        public string Note { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        public virtual VehicleType VehicleType { get; set; }
        public string Capacity { get; set; }
        public string EngineIDNo { get; set; }

    }
}

using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class RecordProfile: BaseEntity
    {
        public int VehicleId { get; set; }
        public int VehicleOwnerId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(UpdatedUserId))]
        public virtual User UpdatedUser { get; set; }
        [ForeignKey(nameof(VehicleOwnerId))]
        public virtual CitizenShipProfile VehicleOwner{ get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; }
    }
}

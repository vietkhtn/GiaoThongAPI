using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class MarginalSanctionsTable: BaseEntity
    {
        public DateTime TimeViolation { get; set; }
        public string Location { get; set; }
        public string AttachmentUrl { get; set; }
        public float VAT { get; set; }
        public int TotalMoney { get; set; }
        public int VehicleId { get; set; }
        public string Note { get; set; }
        public int UserHandleerId { get; set; }
        public bool Filed { get; set; } = false;
        public int CitizenShipProfileId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; }
        [ForeignKey(nameof(UserHandleerId))]
        public virtual User UserHandleer { get; set; }
        [ForeignKey(nameof(CitizenShipProfileId))]
        public virtual CitizenShipProfile CitizenShipProfile { get; set; }
        public virtual ICollection<PenaltyVoucher> PenaltyVouchers { get; set; }
    }
}

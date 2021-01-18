using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class DetailViolation: BaseEntity
    {
        public int TableId { get; set; }
        public int ViolationId { get; set; }
        public int Money { get; set; }
        public string Note { get; set; }
        [ForeignKey(nameof(TableId))]
        public virtual MarginalSanctionsTable GetMarginalSanctionsTable { get; set; }
        [ForeignKey(nameof(ViolationId))]
        public virtual Violation Violation { get; set; }
    }
}

using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class PenaltyVoucher: BaseEntity
    {
        [Key,ForeignKey(nameof(MarginalSanctionsTable))]
        public override  int Id { get; set; }
        public int BankId { get; set; }
        public int PayerUserId { get; set; }
        public int MoneyNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MarginalSanctionsTable MarginalSanctionsTable { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }
        [ForeignKey(nameof(PayerUserId))]
        public virtual User PayerUser { get; set; }
    }
}

using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class Bank: BaseEntity
    {
        public string NameBank { get; set; }
        public virtual ICollection<PenaltyVoucher> PenaltyVouchers { get; set; }
    }
}

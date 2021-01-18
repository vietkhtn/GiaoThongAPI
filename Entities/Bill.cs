using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class Bill: BaseEntity
    {
        [Key,ForeignKey(nameof(Vehicle))]
        public override int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MoneyTotal { get; set; }
        public int userId { get; set; }
        [ForeignKey(nameof(userId))]
        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}

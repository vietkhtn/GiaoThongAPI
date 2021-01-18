using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class Violation: BaseEntity
    {
        public string Description { get; set; }
        public string AttachmentUrl { get; set; }
        public virtual ICollection<DetailViolation> DetailViolations { get; set; }
    }
}

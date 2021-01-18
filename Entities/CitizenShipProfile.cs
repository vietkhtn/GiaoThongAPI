using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Entities
{
    public class CitizenShipProfile: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }

        public virtual ICollection<RecordProfile> RecordProfiles { get; set; }
        public virtual ICollection<MarginalSanctionsTable> MarginalSanctionsTables { get; set; }
        public virtual ICollection<DriversLicense> DriversLicenses { get; set; }
    }
}

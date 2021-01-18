using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class CitizenShipProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNo { get; set; }

      
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }

     
    }
}

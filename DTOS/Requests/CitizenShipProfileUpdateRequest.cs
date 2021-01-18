using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Requests
{
    public class CitizenShipProfileUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string Gender { get; set; }
    }
}

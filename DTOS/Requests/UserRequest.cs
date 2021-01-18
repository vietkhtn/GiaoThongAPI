using HR.Helpers.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.DTOS.Requests
{
    public class UserRequest
    {
        [EmailAddress]
        [EmailUniqueAttribute]
        public string Email { get; set; }
        [EmailUniqueAttribute]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Addresses { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }
        public int? RoleId { set; get; }
       
    }
}

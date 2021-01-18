using IThong.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResource.ApplicationCore.Entities
{
    public class User: BaseEntity
    {
        [Key,ForeignKey(nameof(CitizenShipProfile))]
        public override int Id { get; set; }

        public string Email { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateCreateNewPassword { set; get; } = null;

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; } = true;
        public int? RoleId { set; get; }
    
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { set; get; }
        public virtual CitizenShipProfile CitizenShipProfile { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
     
   
        

    }
}
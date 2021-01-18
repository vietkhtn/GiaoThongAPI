using HumanResource.ApplicationCore.Entities;
using HumanResource.ApplicationCore.Interfaces;
using HumanResource.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HR.Helpers.CustomValidationAttribute
{
    public class EmailUniqueAttribute: ValidationAttribute
    {
       
        protected override   ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value != null)
            {
               
                Expression<Func<User, bool>> filter = emp => emp.Email == value.ToString() || emp.Username == value.ToString(); 
                var unitOfWork = (IUnitOfWork)validationContext.GetService(typeof(IUnitOfWork));
                var entity =  unitOfWork.Repository<User>().SingleOrDefault(new BaseSpecification<User>(filter));
                if (entity != null)
                {
                    return new ValidationResult(GetErrorMessage(value.ToString()));
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email or Username {email} is already in use.";
        }
    }
}

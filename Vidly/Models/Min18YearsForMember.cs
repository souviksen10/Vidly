using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsForMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerObj = (Customer)validationContext.ObjectInstance;
            if (customerObj.MembershipTypeId == MembershipType.Unknown || customerObj.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customerObj.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Now.Year - customerObj.BirthDate.Value.Year;
            return (age>=18) ?  ValidationResult.Success: new ValidationResult("Customer has to be minimum 18 years to become a member");
        }
    }
}
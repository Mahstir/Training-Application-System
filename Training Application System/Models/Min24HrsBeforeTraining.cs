using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Application_System.Models
{
    public class Min24HrsBeforeTraining : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var training = (Training)validationContext.ObjectInstance;

            if (training.Capacity > 0)
                return ValidationResult.Success;

            return new ValidationResult("A training cannot have a capacity of zero");
        }
    }
}
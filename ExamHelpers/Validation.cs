using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChushkaWebApp.Utilities
{
   public class Validation
    {
        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);

            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }
    }
}

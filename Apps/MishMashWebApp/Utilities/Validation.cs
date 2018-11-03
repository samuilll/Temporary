using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MishMashWebApp.Utilities
{
   public static class Validation
    {
        public static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);

            ICollection<ValidationResult> collection = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, validationContext, collection, true);
        }
    }
}

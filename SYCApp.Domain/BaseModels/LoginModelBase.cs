using System;
using System.ComponentModel.DataAnnotations;

namespace SYCApp.Domain.BaseModels
{
    //public abstract class LoginModelBase : IValidatableObject
    public abstract class LoginModelBase
    {

        [Required]
        [StringLength(75)]
        [EmailAddress]
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime LoginDateTime { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return new ValidationResult("There are no validations set up yet", new[] { nameof(LoginDateTime) });
        }
    }
}


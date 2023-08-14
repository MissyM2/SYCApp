using System;
using System.ComponentModel.DataAnnotations;

namespace SYCApp.Domain.BaseModels
{
    public abstract class UserModelBase
    {

        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public string LastName { get; set; }

        [Required]
        [StringLength(75)]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(75)]
        public string HashedPassword { get; set; }
    }
}



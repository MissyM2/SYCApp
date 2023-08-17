using System;
using System.ComponentModel.DataAnnotations;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class UserModel : BaseEntity
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

        public List<LoginModel> LoginModels { get; set; } = new List<LoginModel>();
    }
}


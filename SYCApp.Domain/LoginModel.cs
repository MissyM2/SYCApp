using System;
using System.ComponentModel.DataAnnotations;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class LoginModel : BaseEntity
    {

        [Required]
        [StringLength(75)]
        [EmailAddress]
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime LoginDateTime { get; set; }

        public int UserId { get; set; }

        public virtual UserModel? AppUser { get; set; }
        
    }
}


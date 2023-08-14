using System;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class LoginModel : LoginModelBase
    {
        public int Id { get; set; }
        public UserModel? AppUser { get; set; }
        public int UserId { get; set; }
    }
}


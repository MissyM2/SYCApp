using System;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class LoginModel : LoginModelBase
    {
        public int UserId { get; set; }

        public virtual UserModel? AppUser { get; set; }
        
    }
}


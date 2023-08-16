using System;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class UserModel : UserModelBase
    {
        public List<LoginModel> LoginModels { get; set; } = new List<LoginModel>();
    }
}


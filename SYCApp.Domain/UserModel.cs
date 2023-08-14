using System;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Domain
{
    public class UserModel : UserModelBase
    {

        public int Id { get; set; }

        public List<LoginModel>? LoginModels { get; set; }
    }
}


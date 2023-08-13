using System;
using SYCApp.Maui.Core.Database;

namespace SYCApp.Maui.Core.Domain
{
    public class UserModel : BaseDatabaseItem
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

    }
}
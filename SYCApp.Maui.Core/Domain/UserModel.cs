using System;
using SYCApp.Maui.Core.Database;

namespace SYCApp.Maui.Core.Domain
{
    public class UserModel : BaseDatabaseItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string HashedPassword { get; set; }

    }
}
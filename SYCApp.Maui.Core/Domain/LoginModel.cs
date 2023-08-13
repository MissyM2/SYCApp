using System;
using SYCApp.Maui.Core.Database;

namespace SYCApp.Maui.Core.Domain
{
    public class LoginModel : BaseDatabaseItem
    {
        public string Username { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}

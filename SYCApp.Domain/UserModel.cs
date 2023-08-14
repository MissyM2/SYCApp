using System;
namespace SYCApp.Domain
{
    public class UserModel
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? HashedPassword { get; set; }

        public List<LoginModel> LoginModels { get; set; }
    }
}


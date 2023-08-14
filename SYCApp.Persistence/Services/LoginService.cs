using System;
using SYCApp.Core.DataServices;
using SYCApp.Domain;

namespace SYCApp.Persistence.Services
{
	public class LoginService : ILoginService
    {
        private readonly SYCAppDbContext _context;

        public LoginService(SYCAppDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<UserModel> GetExistingUserModels()
        {
            return _context.Users.ToList();
        }

        public void Save(LoginModel login)
        {
            _context.Add(login);
            _context.SaveChanges();
        }
    }
}

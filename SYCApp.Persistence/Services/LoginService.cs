using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Services
{
	public class LoginService : GenericRepository<LoginModel>, ILoginService
    {

        public LoginService(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

    }
}

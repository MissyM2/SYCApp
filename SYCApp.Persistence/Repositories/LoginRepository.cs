using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
	public class LoginRepository : GenericRepository<LoginModel>, ILoginRepository
    {

        public LoginRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

    }
}

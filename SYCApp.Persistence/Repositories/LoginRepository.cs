using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
	public class LoginRepository : AsyncRepositoryBase<LoginModel>, ILoginRepository
    {

        public LoginRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<LoginModel> GetByUsername(string userName)
            => FirstOrDefault(w => w.Username  == userName);

    }
}

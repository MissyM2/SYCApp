using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {

        public UserRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserModel>> GetExistingUserModelsByUsername(string emailAddress)
        {
            return _dbContext.Users.Where(x => x.UserEmail == emailAddress).ToList();
        }
    }
}


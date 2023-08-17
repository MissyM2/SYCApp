using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
    public class UserRepository : AsyncRepositoryBase<UserModel>, IUserRepository
    {

        public UserRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<UserModel>> GetExistingUserModelsByUsername(string emailAddress) =>
            GetWhere(x => x.UserEmail == emailAddress);

    }
}


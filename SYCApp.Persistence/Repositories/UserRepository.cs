using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {

        public UserRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return FindAll()
                .OrderBy(lo => lo.LastName)
                .ToList();
        }

        public UserModel GetUserById(int userId)
        {
            return FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefault();
        }

        public UserModel GetUserWithDetails(int userId)
        {
            return FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefault();
        }

        public void CreateUser(UserModel user) => Create(user);

        public void UpdateUser(UserModel user) => Update(user);

        public void DeleteUser(UserModel user) => Delete(user);

        IEnumerable<UserModel> IUserRepository.GetExistingUserModelsByUsername(string emailAddress)
        {
            return _dbContext.Users.Where(x => x.UserEmail == emailAddress).ToList();
        }
    }
}


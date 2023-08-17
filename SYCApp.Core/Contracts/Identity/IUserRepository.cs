using System;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain;

namespace SYCApp.Core.Contracts.Identity
{
	public interface IUserRepository : IRepositoryBase<UserModel>
	{

        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(int userId);
        UserModel GetUserWithDetails(int userId);
        void CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
        IEnumerable<UserModel> GetExistingUserModelsByUsername(string emailAddress);
    }
}


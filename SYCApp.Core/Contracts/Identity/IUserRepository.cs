using System;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain;

namespace SYCApp.Core.Contracts.Identity
{
	public interface IUserRepository : IAsyncRepositoryBase<UserModel>
	{

        Task<IEnumerable<UserModel>> GetExistingUserModelsByUsername(string emailAddress);
    }
}


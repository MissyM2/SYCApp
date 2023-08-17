using System;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain;

namespace SYCApp.Core.Contracts.Identity
{
	public interface ILoginRepository : IAsyncRepositoryBase<LoginModel>
    {
        Task<LoginModel> GetByUsername(string userName);
    }
}


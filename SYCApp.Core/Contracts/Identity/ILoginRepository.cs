using System;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain;

namespace SYCApp.Core.Contracts.Identity
{
	public interface ILoginRepository : IRepositoryBase<LoginModel>
    {
        IEnumerable<LoginModel> GetAllLogins();
        LoginModel GetLoginById(int loginId);
        LoginModel GetLoginWithDetails(int loginId);
        void CreateLogin(LoginModel login);
        void UpdateLogin(LoginModel login);
        void DeleteLogin(LoginModel login);
    }
}


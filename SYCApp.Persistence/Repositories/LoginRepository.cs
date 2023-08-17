using System;
using Microsoft.EntityFrameworkCore;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Domain;

namespace SYCApp.Persistence.Repositories
{
	public class LoginRepository : RepositoryBase<LoginModel>, ILoginRepository
    {

        public LoginRepository(SYCAppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<LoginModel> GetAllLogins()
        {
            return FindAll()
                .OrderBy(lo => lo.Username)
                .ToList();
        }

        public LoginModel GetLoginById(int loginId)
        {
            return FindByCondition(login => login.Id.Equals(loginId))
                .FirstOrDefault();
        }

        public LoginModel GetLoginWithDetails(int loginId)
        {
            return FindByCondition(login => login.Id.Equals(loginId))
                .Include(us => us.AppUser)
                .FirstOrDefault();
        }

        public void CreateLogin(LoginModel login) => Create(login);

        public void UpdateLogin(LoginModel login) => Update(login);

        public void DeleteLogin(LoginModel login) => Delete(login);
    }
}

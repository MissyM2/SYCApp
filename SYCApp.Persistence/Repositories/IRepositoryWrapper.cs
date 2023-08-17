using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Contracts.Persistence;

namespace SYCApp.Persistence.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
    {
        private SYCAppDbContext _repoContext;
        private ILoginRepository _login;
        private IUserRepository _user;
        public ILoginRepository Login
        {
            get
            {
                if (_login == null)
                {
                    _login = new LoginRepository(_repoContext);
                }
                return _login;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(SYCAppDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}


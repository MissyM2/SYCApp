using System;
using SYCApp.Core.Contracts.Identity;

namespace SYCApp.Core.Contracts.Persistence
{
    public interface IRepositoryWrapper
    {
        ILoginRepository Login { get; }
        IUserRepository User { get; }
        void Save();
    }
}

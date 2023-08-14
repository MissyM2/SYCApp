using System;
using SYCApp.Domain;

namespace SYCApp.Core.DataServices
{
	public interface IUserService
	{
        void Save(UserModel userModel);

        IEnumerable<UserModel> GetExistingUserModels(string emailAddress);
    }
}


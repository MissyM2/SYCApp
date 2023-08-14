using System;
using SYCApp.Domain;

namespace SYCApp.Core.DataServices
{
	public interface ILoginService
    {
        void Save(LoginModel loginModel);

        IEnumerable<UserModel> GetExistingUserModels();
    }
}


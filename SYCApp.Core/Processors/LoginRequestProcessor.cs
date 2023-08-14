using System;
using SYCApp.Core.DataServices;
using SYCApp.Core.Enums;
using SYCApp.Core.Models;
using SYCApp.Domain;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Processors
{
    public class LoginRequestProcessor : ILoginRequestProcessor
    {
        private ILoginService _loginService;

        public LoginRequestProcessor(ILoginService loginService)
        {
            this._loginService = loginService;
        }

        public LoginResult LoginUser(LoginRequest loginRequest)
        {
            // test
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest));
            }

            // test
            var existingUsers = _loginService.GetExistingUserModels();

            var result = CreateLoginObject<LoginResult>(loginRequest);

            // save test
            if (existingUsers.Any())
            {
                var user = existingUsers.First();

                var login = CreateLoginObject<LoginModel>(loginRequest);
                login.UserId = user.Id;

                
                _loginService.Save(login);

                // test
                result.LoginId = login.Id;

                // test
                result.Flag = LoginResultFlag.Success;
            }
            // not save test
            else
            {

                // test
                result.Flag = LoginResultFlag.Failure;
            }
           

            return result;
        }

        // creation of a generic so I can use it in the above becauxe there is a lot of duplication
        private static TLoginModel CreateLoginObject<TLoginModel>(LoginRequest loginRequest) where TLoginModel
            : LoginModelBase, new()
        {
            return new TLoginModel
            {
                Username = loginRequest.Username,
                LoginDateTime = loginRequest.LoginDateTime,

            };
        }
    }
}


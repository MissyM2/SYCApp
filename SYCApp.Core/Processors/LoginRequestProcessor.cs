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
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest));
            }



            var result = CreateLoginObject<LoginResult>(loginRequest);
            var tempVar = 1;

            if (tempVar == 3)
            {
                result.Flag = LoginResultFlag.Failure;
            }
            else
            {
                var userLogin = CreateLoginObject<LoginModel>(loginRequest);
                userLogin.UserId = 1;

                _loginService.Save(userLogin);

                result.LoginId = userLogin.Id;
                result.Flag = LoginResultFlag.Success;
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


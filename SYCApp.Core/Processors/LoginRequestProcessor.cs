using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Enums;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Domain;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Processors
{
    public class LoginRequestProcessor : ILoginRequestProcessor
    {
        private ILoginRepository _loginRepository;

        public LoginRequestProcessor(ILoginRepository loginRepository)
        {
            this._loginRepository = loginRepository;
        }

        public async Task<LoginResultDto> LoginUser(LoginRequestDto loginRequest)
        {
            // test
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest));
            }

            // test
            var existingUsers = await _loginRepository.GetAllAsync();

            var result = CreateLoginObject<LoginResultDto>(loginRequest);

            // save test
            if (existingUsers != null)
            {
                var user = existingUsers.FirstOrDefault();

                var login = CreateLoginObject<LoginModel>(loginRequest);
                login.UserId = user.Id;

                
                await _loginRepository.AddAsync(login);

                //_loginRepository.

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
        private static TLoginModel CreateLoginObject<TLoginModel>(LoginRequestDto loginRequest) where TLoginModel
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


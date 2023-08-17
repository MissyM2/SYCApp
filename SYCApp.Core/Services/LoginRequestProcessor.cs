using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Enums;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Domain;
using SYCApp.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace SYCApp.Core.Services
{
    public class LoginRequestProcessor : ILoginRequestProcessor
    {
        private ILoginRepository _loginRepository;
        private IUserRepository _userRepository;

        private LoginModel _loginToBeAdded;
        private LoginResultDto _loginResultDto;

        public LoginRequestProcessor(ILoginRepository loginRepository, IUserRepository userRepository)
        {
            this._loginRepository = loginRepository;
            this._userRepository = userRepository;
        }

        public async Task<LoginResultDto> LoginUser(LoginRequestDto loginRequestDto)
        {
            // test
            if (loginRequestDto == null)
            {
                throw new ArgumentNullException(nameof(loginRequestDto));
            }

            // test
            var existingUsers = await _userRepository.GetAll();

            // save test
            if (existingUsers != null)
            {
                var user = existingUsers.FirstOrDefault();

                _loginToBeAdded = new LoginModel
                {
                    Username = loginRequestDto.Username,
                    LoginDateTime = DateTime.Now,
                    UserId = user.Id
                };

                
                await _loginRepository.Create(_loginToBeAdded);

                _loginResultDto = new LoginResultDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserEmail = user.UserEmail,
                    LoginId = _loginToBeAdded.Id,
                    Flag = LoginResultFlag.Success
                };

            }
            // not save test
            else
            {

                // test
                _loginResultDto.Flag = LoginResultFlag.Failure;
            }
           

            return _loginResultDto;
        }

        // creation of a generic so I can use it in the above becauxe there is a lot of duplication

        // create Login Request Dto
        //private static TLoginRequestDto CreateLoginRequestObject<TLoginRequestDto>(LoginRequestDto loginRequest) where TLoginRequestDto
        //    : BaseEntity, new()
        //{
        //    return new TLoginRequestDto
        //    {
        //        Username = loginRequest.Username,
        //        LoginDateTime = loginRequest.LoginDateTime,

        //    };
        //}

    }
}


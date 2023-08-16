using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Enums;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Domain;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Services
{
    public class UserRequestProcessor : IUserRequestProcessor
    {
        private IUserRepository _userRepository;

        public UserRequestProcessor(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<AddUserResultDto> AddUser(AddUserRequestDto addUserRequest)
        {
            // test
            if (addUserRequest == null)
            {
                throw new ArgumentNullException(nameof(addUserRequest));
            }

            // test
            var existingUsers = _userRepository.GetExistingUserModelsByUsername(addUserRequest.UserEmail);

            var result = CreateAddUserObject<AddUserResultDto>(addUserRequest);

            // test
            if (existingUsers == null)
            {

                var addUser = CreateAddUserObject<UserModel>(addUserRequest);
                //user.UserId = user.Id;


                await _userRepository.AddAsync(addUser);

                // test
                result.UserId = addUser.Id;

                // test
                result.Flag = AddUserResultFlag.Success;
            }
            // not save test
            else
            {

                // test
                result.Flag = AddUserResultFlag.Failure;
            }


            return result;
        }

        // creation of a generic so I can use it in the above becauxe there is a lot of duplication
        private static TUserModel CreateAddUserObject<TUserModel>(AddUserRequestDto addUserRequest) where TUserModel
            : UserModelBase, new()
        {
            return new TUserModel
            {
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                UserEmail = addUserRequest.UserEmail,
                HashedPassword = addUserRequest.HashedPassword,

            };
        }
    }
}

using System;
using SYCApp.Core.DataServices;
using SYCApp.Core.Enums;
using SYCApp.Core.Models;
using SYCApp.Domain;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Processors
{
    public class UserRequestProcessor : IUserRequestProcessor
    {
        private IUserService _userService;

        public UserRequestProcessor(IUserService userService)
        {
            this._userService = userService;
        }

        public AddUserResult AddUser(AddUserRequest addUserRequest)
        {
            // test
            if (addUserRequest == null)
            {
                throw new ArgumentNullException(nameof(addUserRequest));
            }

            // test
            var existingUsers = _userService.GetExistingUserModels(addUserRequest.UserEmail);

            var result = CreateAddUserObject<AddUserResult>(addUserRequest);

            // test
            if (!existingUsers.Any())
            {

                var addUser = CreateAddUserObject<UserModel>(addUserRequest);
                //user.UserId = user.Id;


                _userService.Save(addUser);

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
        private static TUserModel CreateAddUserObject<TUserModel>(AddUserRequest addUserRequest) where TUserModel
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

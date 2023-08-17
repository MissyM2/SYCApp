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

        private UserModel _userToBeAdded;
        private AddUserResultDto _addUserResultDto;

        public UserRequestProcessor(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<AddUserResultDto> AddUser(AddUserRequestDto addUserRequestDto)
        {
            // test
            if (addUserRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addUserRequestDto));
            }

            // test
            var existingUsers = _userRepository.GetExistingUserModelsByUsername(addUserRequestDto.UserEmail);


            // test
            if (existingUsers == null)
            {

                _userToBeAdded = new UserModel
                {
                    FirstName = addUserRequestDto.FirstName,
                    LastName = addUserRequestDto.LastName,
                    UserEmail = addUserRequestDto.UserEmail,
                    HashedPassword = addUserRequestDto.HashedPassword
                };


                await _userRepository.Create(_userToBeAdded);



                // test
                _addUserResultDto.UserId = _userToBeAdded.Id;

                // test
                _addUserResultDto.Flag = AddUserResultFlag.Success;
            }
            // not save test
            else
            {

                // test
                _addUserResultDto.Flag = AddUserResultFlag.Failure;
            }


            return _addUserResultDto;
        }

        // creation of generics so I can use it in the above becauxe there is a lot of duplication

        // create Request Dto
        //private static TAddUserRequestDto CreateAddUserRequestObject<TAddUserRequestDto>(AddUserRequestDto addUserRequest) where TAddUserRequestDto
        //    : AddUserRequestDto, new()
        //{
        //    return new TAddUserRequestDto
        //    {
                
        //        FirstName = addUserRequest.FirstName,
        //        LastName = addUserRequest.LastName,
        //        UserEmail = addUserRequest.UserEmail,
        //        HashedPassword = addUserRequest.HashedPassword,

        //    };
        //}
    }
}

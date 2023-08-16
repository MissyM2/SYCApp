using System;
using SYCApp.Core.DataTransferObjects;

namespace SYCApp.Core.Services
{
	public interface IUserRequestProcessor
	{
        Task<AddUserResultDto> AddUser(AddUserRequestDto addUserRequest);
    }
}


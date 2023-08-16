using System;
using SYCApp.Core.DataTransferObjects;

namespace SYCApp.Core.Processors
{
	public interface IUserRequestProcessor
	{
        Task<AddUserResultDto> AddUser(AddUserRequestDto addUserRequest);
    }
}


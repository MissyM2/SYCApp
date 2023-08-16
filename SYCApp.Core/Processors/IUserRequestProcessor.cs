using System;
using SYCApp.Core.Models;

namespace SYCApp.Core.Processors
{
	public interface IUserRequestProcessor
	{
        Task<AddUserResult> AddUser(AddUserRequest addUserRequest);
    }
}


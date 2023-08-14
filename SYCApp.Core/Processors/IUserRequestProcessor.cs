using System;
using SYCApp.Core.Models;

namespace SYCApp.Core.Processors
{
	public interface IUserRequestProcessor
	{
        AddUserResult AddUser(AddUserRequest addUserRequest);
    }
}


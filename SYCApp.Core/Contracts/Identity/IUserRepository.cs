﻿using System;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Domain;

namespace SYCApp.Core.Contracts.Identity
{
	public interface IUserRepository : IGenericRepository<UserModel>
	{
        Task<List<UserModel>> GetExistingUserModelsByUsername(string emailAddress);
    }
}


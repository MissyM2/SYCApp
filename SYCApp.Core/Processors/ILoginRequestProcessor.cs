using System;
using SYCApp.Core.Models;

namespace SYCApp.Core.Processors
{
    public interface ILoginRequestProcessor
    {
        Task<LoginResult> LoginUser(LoginRequest loginRequest);
    }
}

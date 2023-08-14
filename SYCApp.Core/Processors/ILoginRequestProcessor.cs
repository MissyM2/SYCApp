using System;
using SYCApp.Core.Models;

namespace SYCApp.Core.Processors
{
    public interface ILoginRequestProcessor
    {
        LoginResult LoginUser(LoginRequest loginRequest);
    }
}

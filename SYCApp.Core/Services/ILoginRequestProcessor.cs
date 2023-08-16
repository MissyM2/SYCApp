using System;
using SYCApp.Core.DataTransferObjects;

namespace SYCApp.Core.Services
{
    public interface ILoginRequestProcessor
    {
        Task<LoginResultDto> LoginUser(LoginRequestDto loginRequest);
    }
}

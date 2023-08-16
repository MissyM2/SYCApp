using System;
using SYCApp.Core.DataTransferObjects;

namespace SYCApp.Core.Processors
{
    public interface ILoginRequestProcessor
    {
        Task<LoginResultDto> LoginUser(LoginRequestDto loginRequest);
    }
}

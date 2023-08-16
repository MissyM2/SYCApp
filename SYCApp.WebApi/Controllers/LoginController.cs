using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Core.Services;

namespace SYCApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginRequestProcessor _loginProcessor;
        private readonly IMapper _mapper;

       
        public LoginController(ILoginRequestProcessor loginProcessor, IMapper mapper)
        {
            this._loginProcessor = loginProcessor;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _loginProcessor.LoginUser(request);

                var loginResponse = _mapper.Map<LoginResultDto>(result);

                if (result.Flag == Core.Enums.LoginResultFlag.Success)
                {
                    return Ok(loginResponse);
                }

                ModelState.AddModelError(nameof(LoginRequestDto.LoginDateTime), "No users exist for this id.");
            }

            return BadRequest(ModelState);
        }
    }
}


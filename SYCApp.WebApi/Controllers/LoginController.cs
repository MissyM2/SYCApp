using System;
using Microsoft.AspNetCore.Mvc;
using SYCApp.Core.Models;
using SYCApp.Core.Processors;

namespace SYCApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginRequestProcessor _loginProcessor;

        public LoginController(ILoginRequestProcessor loginProcessor)
        {
            this._loginProcessor = loginProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _loginProcessor.LoginUser(request);
                if (result.Flag == Core.Enums.LoginResultFlag.Success)
                {
                    return Ok(result);
                }

                ModelState.AddModelError(nameof(LoginRequest.LoginDateTime), "No users exist for this id.");
            }

            return BadRequest(ModelState);
        }
    }
}


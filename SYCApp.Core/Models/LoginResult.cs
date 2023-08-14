using System;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Models
{
	public class LoginResult : LoginModelBase
	{
        public LoginResultFlag Flag { get; set; }
        public int? LoginId { get; set; }
    }
}


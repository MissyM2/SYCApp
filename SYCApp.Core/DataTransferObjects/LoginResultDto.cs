using System;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class LoginResultDto : LoginModelBase
	{
        public LoginResultFlag Flag { get; set; }
        public int? LoginId { get; set; }
    }
}


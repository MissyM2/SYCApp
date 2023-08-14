using System;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.Models
{
	public class AddUserResult : UserModelBase
    {
        public AddUserResultFlag Flag { get; set; }
        public int? UserId { get; set; }
    }
}


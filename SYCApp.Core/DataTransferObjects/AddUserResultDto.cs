using System;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class AddUserResultDto : UserModelBase
    {
        public AddUserResultFlag Flag { get; set; }
        public int? UserId { get; set; }
    }
}


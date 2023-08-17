using System;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class AddUserResultDto : BaseEntity
    {
        public AddUserResultFlag Flag { get; set; }
        public int? UserId { get; set; }
    }
}


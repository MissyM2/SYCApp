using System;
using System.ComponentModel.DataAnnotations;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class LoginRequestDto : BaseEntity
	{
        public string Username { get; set; } = string.Empty;

        public DateTime LoginDateTime { get; set; }
    }
}


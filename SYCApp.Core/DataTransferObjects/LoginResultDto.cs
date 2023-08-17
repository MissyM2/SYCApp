using System;
using System.ComponentModel.DataAnnotations;
using SYCApp.Core.Enums;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class LoginResultDto : BaseEntity
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public LoginResultFlag Flag { get; set; }
        public int? LoginId { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using SYCApp.Domain.BaseModels;

namespace SYCApp.Core.DataTransferObjects
{
	public class AddUserRequestDto : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? HashedPassword { get; set; }

    }
}


using System;
using AutoMapper;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Domain;

namespace SYCApp.Core.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserModel, AddUserRequestDto>().ReverseMap();
			CreateMap<UserModel, AddUserResultDto>().ReverseMap();

            CreateMap<LoginModel, LoginRequestDto>().ReverseMap();
            CreateMap<LoginModel, LoginResultDto>().ReverseMap();
        }
	}
}


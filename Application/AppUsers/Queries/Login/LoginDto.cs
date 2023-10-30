﻿using Application.Common.Mappings;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Application.AppUsers.Queries.Login
{
    public class LoginDto : IMapWith<LoginQuery>
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, LoginQuery>()
                .ForMember(query => query.UserName,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ForMember(query => query.Password,
                    opt => opt.MapFrom(dto => dto.Password));
        }
    }
}

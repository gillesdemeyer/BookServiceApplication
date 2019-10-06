using AutoMapper;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Services
{
    public class AutoMapperProfileConfiguration: Profile
    {
        public AutoMapperProfileConfiguration():this("MyProfile")
        {

        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<BookBasic, Book>();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Models;

namespace ToDo.Web.ViewModels.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}

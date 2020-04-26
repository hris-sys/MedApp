using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Models;

namespace ToDo.Web.ViewModels.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryInputModel>();
        }
    }
}

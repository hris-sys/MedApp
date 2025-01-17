﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data;
using ToDo.Web.ViewModels.Users;

namespace ToDo.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(ApplicationDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<UserViewModel> GetAllUsernames(string userId)
        {
            var users = this.DbContext.Users.Where(u => u.Id != userId).ToList();

            var mappedUsers = this.Mapper.Map<IEnumerable<UserViewModel>>(users);

            return mappedUsers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Web.ViewModels.Users;

namespace ToDo.Services
{
    public interface IUserService
    {
        public IEnumerable<UserViewModel> GetAllUsernames();
    }
}

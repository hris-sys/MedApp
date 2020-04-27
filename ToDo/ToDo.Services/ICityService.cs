using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public interface ICityService
    {
        public IEnumerable<City> GetAllCities();
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public class CityService : BaseService, ICityService
    {
        public CityService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IEnumerable<City> GetAllCities()
        {
            var result = this.DbContext.Cities.ToList();

            return result;
        }
    }
}

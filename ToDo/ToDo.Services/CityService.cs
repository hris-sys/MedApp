using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public class CityService : BaseService, ICityService
    {
        public CityService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> CreateAsync(string name)
        {
            var city = new City()
            {
                Name = name
            };

            await this.DbContext.Cities.AddAsync(city);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var city = await this.DbContext
                                   .Cities
                                   .Where(city => city.Id == id)
                                   .FirstOrDefaultAsync();

            if (city == null)
            {
                return false;
            }

            var users = await this.DbContext
                                  .Users
                                  .Where(user => user.CityId == id)
                                  .ToListAsync();

            foreach (var user in users)
            {
                user.CityId = 1;
            }

            this.DbContext.Cities.Remove(city);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<City> GetAllCities()
        {
            var result = this.DbContext.Cities.Where(city => city.Id > 1).ToList();

            return result;
        }
    }
}

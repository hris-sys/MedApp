using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public interface ICityService
    {
        public IEnumerable<City> GetAllCities();

        public Task<bool> CreateAsync(string name);

        public Task<bool> DeleteByIdAsync(int id);

    }
}

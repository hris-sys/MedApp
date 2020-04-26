using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public interface ICategoryService
    {
        public Task<bool> CreateAsync(string name);

        public Task<bool> DeleteByIdAsync(int id);

        public Task<IEnumerable<T>> GetAllAsync<T>();
    }
}

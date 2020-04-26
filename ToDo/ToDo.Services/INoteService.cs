using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public interface INoteService
    {
        public Task<bool> CreateAsync(int categoryId, string title, DateTime expiresOn, string userId, string description = null);

        public Task<bool> DeleteAsync(int id);

        public Category GetById(int id);

        public IEnumerable<T> GetAll<T>();
    }
}

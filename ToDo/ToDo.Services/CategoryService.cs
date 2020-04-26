using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<bool> CreateAsync(string name)
        {
            var category = new Category
            {
                Name = name,
            };

            await this.DbContext.Categories.AddAsync(category);

            await this.DbContext.SaveChangesAsync();

            return category.Id != 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await this.DbContext
                                   .Categories
                                   .FirstOrDefaultAsync(s => s.Id == id);

            if (entity != null)
            {
                this.DbContext.Categories.Remove(entity);

                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var categories = await this.DbContext.Categories.ToArrayAsync();

            var mappedCategories = this.Mapper.Map<IEnumerable<T>>(categories);

            return mappedCategories;
        }
    }
}

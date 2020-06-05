using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Categories;

namespace ToDo.Services
{
    public interface ICategoryService
    {
        public Task<bool> CreateAsync(string name, string ImageUrl);

        public Task<bool> DeleteByIdAsync(int id);

        public Task<IEnumerable<T>> GetAllAsync<T>();

        public CategoryModel GetById(int id);

        public bool EditCategory(CategoryModel editCategoryModel);

    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Categories;

namespace ToDo.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly INoteService noteService;

        public CategoryService(ApplicationDbContext dbContext, IMapper mapper, INoteService noteService)
            : base(dbContext, mapper)
        {
            this.noteService = noteService;
        }

        public async Task<bool> CreateAsync(string name, string imageUrl)
        {
            var category = new Category
            {
                Name = name,
                ImageUrl = imageUrl
            };

            await this.DbContext.Categories.AddAsync(category);

            await this.DbContext.SaveChangesAsync();

            return category.Id != 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await this.DbContext
                                   .Categories
                                   .Include(category => category.Notes)
                                   .FirstOrDefaultAsync(s => s.Id == id);

            if (entity != null)
            {
                this.noteService.DeleteAllNotesByCategoryId(entity.Id);

                this.DbContext.Categories.Remove(entity);

                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public bool EditCategory(CategoryModel editCategoryModel)
        {
            var category = this.DbContext.Categories.Where(cat => cat.Id == editCategoryModel.Id).SingleOrDefault();
            category.ImageUrl = editCategoryModel.ImageUrl;
            category.Name = editCategoryModel.Name;

            this.DbContext.Update(category);
            this.DbContext.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var categories = await this.DbContext.Categories.ToArrayAsync();

            var mappedCategories = this.Mapper.Map<IEnumerable<T>>(categories);

            return mappedCategories;
        }

        public CategoryModel GetById(int id)
        {
            var category = this.DbContext.Categories
                            .Where(a => a.Id == id)
                            .Select(cat => new CategoryModel()
                            {
                                ImageUrl = cat.ImageUrl,
                                Name = cat.Name,
                                Id = cat.Id
                            })
                            .SingleOrDefault();

            return category;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services;
using ToDo.Web.ViewModels.Categories;

namespace ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> All()
        {
            var categories = await categoryService.GetAllAsync<CategoryModel>();

            return this.View(categories);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToPage("/Home/Error");
            }
            await categoryService.CreateAsync(category.Name, category.ImageUrl);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteByIdAsync(id);

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var category = categoryService.GetById(id);

            return this.View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel editCategoryModel)
        {
            categoryService.EditCategory(editCategoryModel);

            return RedirectToAction("All");
        }
    }
}
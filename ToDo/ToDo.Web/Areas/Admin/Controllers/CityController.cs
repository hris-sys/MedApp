using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Services;
using ToDo.Web.ViewModels.Cities;

namespace ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult All()
        {
            var cities = this.cityService.GetAllCities();

            return this.View(cities);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await cityService.DeleteByIdAsync(id);

            return RedirectToAction("All");
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityInputViewModel city)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToPage("/Home/Error");
            }

            await this.cityService.CreateAsync(city.Name);

            return RedirectToAction("All");
        }
    }
}

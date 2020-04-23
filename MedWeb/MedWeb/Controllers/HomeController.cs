using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedWeb.Models;
using Microsoft.AspNetCore.Identity;
using MedWeb.Data;

namespace MedWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext context;

        public HomeController(UserManager<ApplicationUser> userManager, 
                              SignInManager<ApplicationUser> signInManager, 
                              RoleManager<IdentityRole> roleManager,
                              ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        public IActionResult Index()
        {

            return this.View();
        }

        public async Task<IActionResult> Privacy()
        {
            //await this.roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

            //await this.roleManager.CreateAsync(new IdentityRole { Name = "Patient" });

            //var user = new ApplicationUser()
            //{
            //    FirstName = "test",
            //    LastName = "tester",
            //    Email = "test@tester.bg",
            //    UserName = "testTest",
            //};

            //await this.userManager.CreateAsync(user, "somePassword123!");
            //await this.userManager.AddToRoleAsync(user, "Admin");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

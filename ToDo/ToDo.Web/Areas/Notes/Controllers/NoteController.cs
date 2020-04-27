using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Services;
using ToDo.Web.ViewModels.Categories;
using ToDo.Web.ViewModels.Notes;

namespace ToDo.Web.Areas.Notes.Controllers
{
    [Authorize]
    [Area("Notes")]
    public class NoteController : Controller
    {
        private readonly INoteService noteService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public NoteController(INoteService noteService, ICategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.noteService = noteService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var notes = noteService.GetAllNotes<NoteViewModel>();

            return View(notes);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.GetAllAsync<CategoryInputModel>();

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoteInputModel noteInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(noteInputModel);
            }


            await noteService.CreateAsync(noteInputModel.CategoryId,
                noteInputModel.Title,
                noteInputModel.ExpiredOn,
                userManager.GetUserId(User),
                noteInputModel.Description
                );

            return Redirect("/");
        }
    }
}

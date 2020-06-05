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
        public async Task<IActionResult> Index()
        {
            await this.noteService.ValidateMessageAsync(this.userManager.GetUserId(this.User));

            var notes = noteService.GetAllNotes(this.userManager.GetUserId(this.User));
            
            return View(notes);
        }

        public async Task<IActionResult> GetDeletedNotes()
        {
            var deletedNotes = await this.noteService.GetAllDeletedNotesAsync(userManager.GetUserId(this.User));

            return this.View(deletedNotes);
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            await this.noteService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.GetAllAsync<CategoryModel>();

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
                noteInputModel.Description);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.noteService.SetIsDeletedAsync(id);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Restore(int id)
        {
            await this.noteService.RestoreMessageAsync(id);

            return RedirectToAction("GetDeletedNotes");
        }
    }
}

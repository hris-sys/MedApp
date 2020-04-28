using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Services;
using ToDo.Web.ViewModels.Messages;

namespace ToDo.Web.Areas.Messages.Controllers
{
    [Authorize]
    [Area("Messages")]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public MessageController(IMessageService messageService,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            this.messageService = messageService;
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<IActionResult> GetAllMessages()
        {
            string id = this.userManager.GetUserId(this.User);

            var messages = await messageService.GetAllMessagesAsync(id);

            return View(messages);
        }

        public IActionResult Create()
        {
            this.ViewData["Users"] = userService.GetAllUsernames(userManager.GetUserId(this.User));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageInputModel messageInputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(messageInputModel);
            }

            await messageService.CreateMessageAsync(
                messageInputModel.Title,
                messageInputModel.Content,
                messageInputModel.ReceiverUserId,
                userManager.GetUserId(this.User)
                );

            return Redirect("/");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.messageService.DeleteMessageAsync(id);

            return RedirectToAction("GetAllMessages");
        }
    }
}
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

        public async Task<IActionResult> GetAllReceivedMessages()
        {
            string id = this.userManager.GetUserId(this.User);

            var messages = await messageService.GetAllReceivedMessagesAsync(id);

            return View(messages);
        }

        public async Task<IActionResult> GetAllSentMessages()
        {
            string id = this.userManager.GetUserId(this.User);

            var messages = await messageService.GetAllSentMessagesAsync(id);

            return View(messages);
        }

        public async Task<IActionResult> GetDeletedMessages()
        {
            var results = await this.messageService.GetAllDeletedMessagesAsync(userManager.GetUserId(this.User));

            return this.View(results);
        }

        public async Task<IActionResult> HardDeleteMessage(string id)
        {
            bool isDeleted = await this.messageService.DeleteMessageAsync(id);

            if (!isDeleted)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("GetDeletedMessages");
        }

        public IActionResult Create()
        {
            this.ViewData["Users"] = userService.GetAllUsernames(userManager.GetUserId(this.User));
            return this.View();
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
                userManager.GetUserId(this.User));

            return RedirectToAction("GetAllReceivedMessages");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.messageService.SetIsDeletedAsync(id);
            //Unintential feature: When deleted by the sender, it gets deleted to the receiver
            return RedirectToAction("GetAllReceivedMessages");
        }


        public async Task<IActionResult> Restore(string id)
        {
            await this.messageService.RestoreMessageAsync(id);

            return RedirectToAction("GetDeletedMessages");
        }
    }
}
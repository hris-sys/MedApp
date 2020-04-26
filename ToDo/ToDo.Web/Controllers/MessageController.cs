using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data.Models;
using ToDo.Services;
using ToDo.Web.ViewModels.Messages;

namespace ToDo.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly UserManager<ApplicationUser> userManager;

        public MessageController(IMessageService messageService,
            UserManager<ApplicationUser> userManager)
        {
            this.messageService = messageService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> GetAllMessages(string id)
        {
            var messages = await messageService.GetAllMessagesAsync<MessageInputModel>(id);

            return this.View(messages);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MessageInputModel messageInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(messageInputModel);
            }

            //FIX THIS TO BE ANOTHER USER
            //IT SENDS TO THE LOGGED IN USER NOW

            messageService.CreateMessageAsync(
                messageInputModel.Title,
                messageInputModel.Content,
                this.userManager.GetUserId(this.User));

            return Redirect("/");
        }
    }
}
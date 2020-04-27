using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Messages;

namespace ToDo.Services
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(ApplicationDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<bool> CreateMessageAsync(string title, string content, string userId)
        {
            var model = await CreateMessageAsync(title, content);

            ApplicationUserMessage applicationUserMessage = new ApplicationUserMessage
            {
                ApplicationUserId = userId,
                MessageId = model,
            };


            await this.DbContext.ApplicationUsersMessages.AddAsync(applicationUserMessage);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        private async Task<string> CreateMessageAsync(string title, string content)
        {
            Message message = new Message
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.UtcNow,
            };

            await this.DbContext.Messages.AddAsync(message);

            await this.DbContext.SaveChangesAsync();

            return message.Id;
        }

        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            var message = await this.DbContext.ApplicationUsersMessages
                .FirstOrDefaultAsync(m => m.MessageId == messageId);

            message.IsDeleted = true;

            //this.DbContext.Update?

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync(string id)
        {
            var messages = await this.DbContext.Messages
                .Where(u => u.ApplicationUserMessages.Any(m => m.ApplicationUserId == id))
                .Select(message => new MessageViewModel
                {
                    Content = message.Content,
                    CreatedOn = message.CreatedOn,
                    Title = message.Title,
                    Username = message.ApplicationUserMessages.FirstOrDefault(um => um.MessageId == message.Id).ApplicationUser.UserName
                })
                .ToArrayAsync();

            return messages;
        }

        public Message GetMessageById(string messageId)
        {
            var item = this.DbContext.Messages.FirstOrDefault(m => m.Id == messageId);

            return item;
        }
    }
}

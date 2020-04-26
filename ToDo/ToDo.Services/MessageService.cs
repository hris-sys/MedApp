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

        public async Task<IEnumerable<T>> GetAllMessagesAsync<T>(string id)
        {
            var messages = await this.DbContext.ApplicationUsersMessages
                .Where(u => u.ApplicationUserId == id)
                .Select(m => new Message
                {
                    Title = m.Message.Title,
                    Content = m.Message.Content,
                })
                .ToArrayAsync();

            var mappedMessages = this.Mapper.Map<IEnumerable<T>>(messages);

            return mappedMessages;
        }

        public Message GetMessageById(string messageId)
        {
            var item = this.DbContext.Messages.FirstOrDefault(m => m.Id == messageId);

            return item;
        }
    }
}

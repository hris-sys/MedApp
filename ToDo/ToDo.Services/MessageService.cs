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

        public async Task<bool> CreateMessageAsync(string title, string content, string recipientId, string senderId)
        {
            Message message = new Message
            {
                Title = title,
                Content = content,
                CreatedOn = DateTime.UtcNow,
                RecipientId = recipientId,
                SenderId = senderId,
            };

            await this.DbContext.Messages.AddAsync(message);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteMessageAsync(string messageId)
        {
            var message = await this.DbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == messageId);

            message.IsDeleted = true;

            this.DbContext.Update(message);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllMessagesAsync(string id)
        {

            var messages = await this.DbContext.Messages
                .Where(u => u.RecipientId == id || u.SenderId == id)
                .OrderByDescending(ord => ord.CreatedOn)
                .Select(message => new MessageViewModel
                {
                    Content = message.Content,
                    CreatedOn = message.CreatedOn,
                    Title = message.Title,
                    ReceiverUserName = message.Recipient.UserName,
                    SenderUserName = message.Sender.UserName,
                    IsDeleted = message.IsDeleted,
                    Id = message.Id,
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

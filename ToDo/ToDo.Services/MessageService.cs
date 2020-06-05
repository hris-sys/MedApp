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
        //Implement Error handling
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

            this.DbContext.Messages.Remove(message);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetIsDeletedAsync(string messageId)
        {
            var message = await this.DbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == messageId);

            message.IsDeleted = true;

            message.DeletedOn = DateTime.UtcNow;

            this.DbContext.Update(message);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RestoreMessageAsync(string messageId)
        {
            var message = await this.DbContext.Messages
                .FirstOrDefaultAsync(m => m.Id == messageId);

            message.IsDeleted = false;

            this.DbContext.Update(message);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllReceivedMessagesAsync(string id)
        {
            var messages = await this.DbContext.Messages
                .Where(u => u.RecipientId == id && u.IsDeleted == false)
                .OrderByDescending(ord => ord.CreatedOn)
                .Select(message => new MessageViewModel
                {
                    Content = message.Content,
                    CreatedOn = message.CreatedOn,
                    Title = message.Title,
                    ReceiverUserName = message.Recipient.UserName,
                    SenderUserName = message.Sender.UserName,
                    Id = message.Id,
                })
                .ToArrayAsync();

            return messages;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllDeletedMessagesAsync(string id)
        {
            var messages = await this.DbContext.Messages
                .Where(u => (u.RecipientId == id || u.SenderId == id)  && u.IsDeleted == true)
                .OrderByDescending(ord => ord.DeletedOn)
                .Select(message => new MessageViewModel
                {
                    Content = message.Content,
                    CreatedOn = message.CreatedOn,
                    Title = message.Title,
                    ReceiverUserName = message.Recipient.UserName,
                    SenderUserName = message.Sender.UserName,
                    Id = message.Id,
                    DeletedOn = message.DeletedOn,
                })
                .ToArrayAsync();

            return messages;
        }

        public async Task<IEnumerable<MessageViewModel>> GetAllSentMessagesAsync(string id)
        {
            var messages = await this.DbContext.Messages
                   .Where(u => u.SenderId == id && u.IsDeleted == false)
                   .OrderByDescending(ord => ord.CreatedOn)
                   .Select(message => new MessageViewModel
                   {
                       Content = message.Content,
                       CreatedOn = message.CreatedOn,
                       Title = message.Title,
                       ReceiverUserName = message.Recipient.UserName,
                       SenderUserName = message.Sender.UserName,
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

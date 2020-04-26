using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Messages;

namespace ToDo.Services
{
    public interface IMessageService
    {
        public Task<bool> CreateMessageAsync(string title, string content, string userId);

        public Task<bool> DeleteMessageAsync(string messageId);

        public Message GetMessageById(string messageId);

        public Task<IEnumerable<T>> GetAllMessagesAsync<T>(string id);
    }
}

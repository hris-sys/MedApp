﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Messages;

namespace ToDo.Services
{
    public interface IMessageService
    {
        public Task<bool> CreateMessageAsync(string title, string content, string recipientId, string senderId);

        public Task<bool> SetIsDeletedAsync(string messageId);

        public Task<bool> DeleteMessageAsync(string messageId);

        public Task<bool> RestoreMessageAsync(string messageId);

        public Message GetMessageById(string messageId);

        public Task<IEnumerable<MessageViewModel>> GetAllReceivedMessagesAsync(string id);

        public Task<IEnumerable<MessageViewModel>> GetAllSentMessagesAsync(string id);

        public Task<IEnumerable<MessageViewModel>> GetAllDeletedMessagesAsync(string id);

    }
}

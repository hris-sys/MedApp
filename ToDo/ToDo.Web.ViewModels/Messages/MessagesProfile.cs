using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data.Models;

namespace ToDo.Web.ViewModels.Messages
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
            CreateMap<Message, MessageInputModel>();
            CreateMap<Message, MessageViewModel>();
        }
    }
}

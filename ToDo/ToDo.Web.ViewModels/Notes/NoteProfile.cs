using AutoMapper;
using ToDo.Data.Models;

namespace ToDo.Web.ViewModels.Notes
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteViewModel>()
                .ForMember(nv => nv.CategoryName, options => options.MapFrom(n => n.Category.Name));
        }
    }
}

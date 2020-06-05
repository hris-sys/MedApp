using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;
using ToDo.Web.ViewModels.Notes;

namespace ToDo.Services
{
    public interface INoteService
    {
        public Task<bool> CreateAsync(int categoryId, string title, DateTime expiresOn, string userId, string description = null);

        public Task<bool> SetIsDeletedAsync(int id);

        public Task<bool> DeleteAsync(int id);

        public Task<bool> RestoreMessageAsync(int id);

        public Task ValidateMessageAsync(string userId); 

        public Category GetById(int id);

        public IEnumerable<NoteViewModel> GetAllNotes(string id);

        public Task<IEnumerable<NoteViewModel>> GetAllDeletedNotesAsync(string id);

        public bool DeleteAllNotesByCategoryId(int id);
    }
}

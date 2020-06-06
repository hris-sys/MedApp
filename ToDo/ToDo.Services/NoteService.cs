using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Data.Models;
using ToDo.Web.ViewModels;
using ToDo.Web.ViewModels.Notes;

namespace ToDo.Services
{
    public class NoteService : BaseService, INoteService
    {
        public NoteService(ApplicationDbContext dbContext, IMapper mapper)
               : base(dbContext, mapper)
        {

        }

        public async Task<bool> CreateAsync(int categoryId, 
            string title, 
            DateTime expiresOn, 
            string userId,
            string desription = null)
        {
            Note note = new Note
            {
                CreatedOn = DateTime.UtcNow,
                Description = desription,
                CategoryId = categoryId,
                Title = title,
                ExpiredOn = expiresOn.Add(new TimeSpan(0, 23, 59, 59)),
                ApplicationUserId = userId,
                IsDeleted = false,
            };

            await this.DbContext.Notes.AddAsync(note);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var note = await this.DbContext.Notes
                .FirstOrDefaultAsync(m => m.Id == id);

            this.DbContext.Notes.Remove(note);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetIsDeletedAsync(int id)
        {
            var entity = await DbContext.Notes.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.IsDeleted = true;

                this.DbContext.Update(entity);

                await DbContext.SaveChangesAsync();

                return true;
            }


            return false;
        }
        public async Task<bool> RestoreMessageAsync(int id)
        {
            var note = await this.DbContext.Notes
                .FirstOrDefaultAsync(m => m.Id == id);

            note.IsDeleted = false;

            if (DateTime.Compare(note.ExpiredOn.Value, DateTime.UtcNow) < 0)
            {
                note.ExpiredOn = DateTime.UtcNow.AddDays(1);
            }

            this.DbContext.Update(note);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<NoteViewModel>> GetAllDeletedNotesAsync(string id)
        {
            var deletedNotes = await DbContext.Notes
                                             .Where(del => del.IsDeleted == true && del.ApplicationUserId == id)
                                             .Include(c => c.Category)
                                             .OrderBy(ord => ord.CreatedOn)
                                             .ThenBy(th => th.ExpiredOn)
                                             .ToArrayAsync();

            var mappedDeletedNotes = this.Mapper.Map<IEnumerable<NoteViewModel>>(deletedNotes);

            return mappedDeletedNotes;
        }

        public IEnumerable<NoteViewModel> GetAllNotes(string id)
        {
            var notes = this.DbContext.Notes
                                      .Where(del => del.IsDeleted == false && del.ApplicationUserId == id)
                                      .Include(c => c.Category)
                                      .OrderBy(ord => ord.CreatedOn)
                                      .ThenBy(th => th.ExpiredOn)
                                      .ToArray();

            var mappedNotes = this.Mapper.Map<IEnumerable<NoteViewModel>>(notes);

            return mappedNotes;
        }

        public Category GetById(int id)
        {
            var item = this.DbContext.Categories.FirstOrDefault(n => n.Id == id);

            return item;
        }

        public async Task ValidateMessageAsync(string userId)
        {
            var allMessage = await this.DbContext.Notes.Where(u => u.ApplicationUserId == userId).ToArrayAsync();

            foreach (var message in allMessage)
            {
                if (DateTime.Compare(DateTime.UtcNow, message.ExpiredOn.Value) > 0)
                {
                    message.IsDeleted = true;
                    this.DbContext.Update(message);
                }
            }
            
            await this.DbContext.SaveChangesAsync();
        }

        public bool DeleteAllNotesByCategoryId(int id)
        {
            var notes = this.DbContext.Notes.Where(not => not.CategoryId == id).ToList();

            this.DbContext.Notes.RemoveRange(notes);

            this.DbContext.SaveChanges();

            return true;
        }

        public string GetUserIdByNoteId(int id)
        {
            return this.DbContext.Notes.Where(us => us.Id == id).SingleOrDefault().ApplicationUserId;
        }
    }
}

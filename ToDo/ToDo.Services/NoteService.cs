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
                ExpiredOn = expiresOn,
                ApplicationUserId = userId,
            };

            await this.DbContext.Notes.AddAsync(note);

            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbContext.Notes.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.IsDeleted = true;

                await DbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public IEnumerable<T> GetAllNotes<T>()
        {
            var notes = this.DbContext.Notes
                                      .Include(n => n.Category)
                                      .ToArray();

            var mappedNotes = this.Mapper.Map<IEnumerable<T>>(notes);

            return mappedNotes;
        }

        public Category GetById(int id)
        {
            var item = this.DbContext.Categories.FirstOrDefault(n => n.Id == id);

            return item;
        }
    }
}

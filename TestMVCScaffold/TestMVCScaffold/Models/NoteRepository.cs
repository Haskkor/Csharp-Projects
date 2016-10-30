using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using EntityState = System.Data.Entity.EntityState;

namespace TestMVCScaffold.Models
{ 
    public class NoteRepository : INoteRepository
    {
        TestMVCScaffoldContext context = new TestMVCScaffoldContext();

        public IQueryable<Note> All
        {
            get { return context.Note; }
        }

        public IQueryable<Note> AllIncluding(params Expression<Func<Note, object>>[] includeProperties)
        {
            IQueryable<Note> query = context.Note;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Note Find(int id)
        {
            return context.Note.Find(id);
        }

        public void InsertOrUpdate(Note note)
        {
            if (note.NoteId == default(int)) {
                // New entity
                context.Note.Add(note);
            } else {
                // Existing entity
                context.Entry(note).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var note = context.Note.Find(id);
            context.Note.Remove(note);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface INoteRepository : IDisposable
    {
        IQueryable<Note> All { get; }
        IQueryable<Note> AllIncluding(params Expression<Func<Note, object>>[] includeProperties);
        Note Find(int id);
        void InsertOrUpdate(Note note);
        void Delete(int id);
        void Save();
    }
}
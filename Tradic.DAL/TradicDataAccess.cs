using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;
using System.Data.Entity;

namespace Tradic.DAL
{
    public class TradicDataAccess : IDataAccess
    {
        TradicContext context = new TradicContext();
        public IEnumerable<Entity.Translation> Translations
        {
            get { return context.Translations; }
        }

        public IEnumerable<Entity.Word> Words
        {
            get { return context.Words; }
        }
        public IEnumerable<Entity.Language> Languages
        {
            get { return context.Languages; }
        }

        public void Change<T>(T entity) where T : Entity.Entity
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void AddEntity<T>(T entity) where T : Entity.Entity
        {
            context.Set(entity.GetType()).Add(entity);
        }

        public void RemoveEntity<T>(T entity) where T : Entity.Entity
        {
            context.Set(entity.GetType()).Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

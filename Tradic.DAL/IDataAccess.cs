using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tradic.DAL.Entity;

namespace Tradic.DAL
{
    public interface IDataAccess
    {
        IEnumerable<Translation> Translations { get; }
        IEnumerable<Word> Words { get; }
        void Change<T>(T entity) where T : Entity.Entity;
        void AddEntity<T>(T entity) where T : Entity.Entity;
        void RemoveEntity<T>(T entity) where T : Entity.Entity;
        void SaveChanges();
    }
}

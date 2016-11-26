using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL;
using Tradic.DAL.Entity;

namespace Tradic.Business
{
    public class WordHelper:IWordHelper
    {
        IDataAccess dataAccess;
        public WordHelper(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void Change<T>(T word) where T : Entity
        {
            dataAccess.Change<T>(word);
            dataAccess.SaveChanges();
        }

        public void AddEntity<T>(T entity) where T : Entity
        {
            dataAccess.AddEntity(entity);
            dataAccess.SaveChanges();
        }

        public void RemoveEntity<T>(T entity) where T : Entity
        {
            dataAccess.RemoveEntity(entity);
            dataAccess.SaveChanges();
        }
        public IEnumerable<Word> GetWords()
        {
            return dataAccess.Words;
        }


        public void ChangeEntity<T>(T entity) where T : Entity
        {
            dataAccess.Change(entity);
            dataAccess.SaveChanges();
        }
    }
}

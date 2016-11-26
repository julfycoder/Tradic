using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL;
using Tradic.DAL.Entity;

namespace Tradic.Business
{
    public class TranslationHelper:ITranslationHelper
    {
        IDataAccess dataAccess;
        public TranslationHelper(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void AddEntity<T>(T entity) where T : Entity
        {
            dataAccess.AddEntity<T>(entity);
            dataAccess.SaveChanges();
        }

        public void RemoveEntity<T>(T entity) where T : Entity
        {
            dataAccess.RemoveEntity<T>(entity);
            dataAccess.SaveChanges();
        }
        public IEnumerable<Translation> GetTranslations()
        {
            return dataAccess.Translations;
        }


        public void ChangeEntity<T>(T entity) where T : Entity
        {
            dataAccess.Change(entity);
            dataAccess.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL;
using Tradic.DAL.Entity;


namespace Tradic.Business
{
    public class LanguageHelper:ILanguageHelper
    {
        IDataAccess dataAccess;
        public LanguageHelper(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void AddEntity<T>(T entity) where T : DAL.Entity.Entity
        {
            dataAccess.AddEntity(entity);
            dataAccess.SaveChanges();
        }

        public void RemoveEntity<T>(T entity) where T : DAL.Entity.Entity
        {
            dataAccess.RemoveEntity(entity);
            dataAccess.SaveChanges();
        }

        public void ChangeEntity<T>(T entity) where T : DAL.Entity.Entity
        {
            dataAccess.Change(entity);
            dataAccess.SaveChanges();
        }

        public IEnumerable<Language> GetLanguages()
        {
            return dataAccess.Languages;
        }
    }
}

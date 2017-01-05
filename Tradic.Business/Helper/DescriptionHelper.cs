using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL;

namespace Tradic.Business.Helper
{
    public class DescriptionHelper:IDescriptionHelper
    {
        IDataAccess dataAccess;
        public DescriptionHelper(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public IEnumerable<DAL.Entity.Description> GetDescriptions()
        {
            return dataAccess.Descriptions;
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
    }
}

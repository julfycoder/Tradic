using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL;
using Tradic.DAL.Entity;

namespace Tradic.Business.Helper
{
    public class EntityHelper:IEntityHelper1
    {
        IDataAccess dataAccess;
        public EntityHelper(IDataAccess dataAccess)
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

        public IEnumerable<T> GetEntities<T>() where T : DAL.Entity.Entity
        {
            throw new NotImplementedException();///////FLYWEIGHT
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;

namespace Tradic.Business.Helper
{
    interface IEntityHelper1
    {
        void AddEntity<T>(T entity) where T : Entity;
        void RemoveEntity<T>(T entity) where T : Entity;
        void ChangeEntity<T>(T entity) where T : Entity;
        IEnumerable<T> GetEntities<T>() where T : Entity;
    }
}

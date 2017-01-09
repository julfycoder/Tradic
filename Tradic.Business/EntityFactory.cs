using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;

namespace Tradic.Business
{
    class EntityFactory
    {
        public Entity GetEntity<T>() where T : Entity
        {
            Entity entity = null;
            string s = typeof(Word).ToString();
            switch (typeof(T).ToString())
            {
                case s:entity= new Word(); break;
                default: break;
            }
            return entity;
        }
    }
}

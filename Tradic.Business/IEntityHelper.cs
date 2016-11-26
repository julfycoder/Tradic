﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradic.DAL.Entity;

namespace Tradic.Business
{
    public interface IEntityHelper
    {
        void AddEntity<T>(T entity) where T : Entity;
        void RemoveEntity<T>(T entity) where T : Entity;
        void ChangeEntity<T>(T entity) where T : Entity;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

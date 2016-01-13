﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dal.Repository
{
    public interface IGenericDal<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        List<TEntity> FindAll();
        TEntity FindById(int id);
    }
}

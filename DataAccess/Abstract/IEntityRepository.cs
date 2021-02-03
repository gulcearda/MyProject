using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip olabilir demek
    //IEntity : IEntity olabilir ve ya IEntity implemente eden bir nesne olabilir demek
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        //backend yazdık
        List<T> GetAll(Expression<Func<T, bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllbyCategory(int categoryId);
    }
}

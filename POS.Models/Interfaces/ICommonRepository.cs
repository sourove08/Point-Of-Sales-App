using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Models.Interfaces
{
   public interface ICommonRepository<T>:IDisposable where T:class 
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetFirstOrDefault(Expression<Func<T,bool>>condition,params Expression<Func<T,object>>[] includes);
        ICollection<T> GetAll();
       bool Add(ICollection<T> entities);
       bool Update(ICollection<T> entities);
       ICollection<T> Get(Expression<Func<T,bool>> Predicate );
    }
}

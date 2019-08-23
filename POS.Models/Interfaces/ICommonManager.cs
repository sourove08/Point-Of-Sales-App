using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Models.Interfaces
{
   public interface ICommonManager<T> where T:class 
    {
        bool Add(T entity);
        bool Add(ICollection<T> entities );
        bool Update(T entity);
        bool Update(ICollection<T> entities);
        bool Remove(long id);
        T GetById(long id,params Expression<Func<T,object>>[] includes);
        ICollection<T> GetAll();
        ICollection<T> Get(Expression<Func<T,bool>> predicate );
    }
}

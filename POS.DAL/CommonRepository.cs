using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using POS.Models.Interfaces;

namespace POS.DAL
{
    public class CommonRepository<T>:ICommonRepository<T> where T:class
    {
        protected DbContext db;

        public DbSet<T> Table
        {
            get { return db.Set<T>(); }
        } 

        public CommonRepository(DbContext dbContext)
        {
            db = dbContext;
        }
        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
          Table.AddOrUpdate(entity);
           return db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public T GetFirstOrDefault(Expression<Func<T,bool>> condition , params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(
                Table.AsQueryable(),(current,include)=>current.Include(include),c=>c.FirstOrDefault(condition));
        }

        //public T GetById(long id)
        //{
        //    return Table.Find(id);
        //}

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public bool Add(ICollection<T> entities)
        {
          Table.AddRange(entities);
           return db.SaveChanges() > 0;
        }

        public bool Update(ICollection<T> entities)
        {
            Table.AddOrUpdate(entities.ToArray());
            return db.SaveChanges() > 0;
        }

        public ICollection<T> Get(Expression<Func<T, bool>> Predicate)
        {
            return Table.AsQueryable().Where(Predicate).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
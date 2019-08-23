using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using POS.DAL;
using POS.Models;
using POS.Models.Interfaces;

namespace POS.BAL
{
    public class StockManger:IStockManager
    {
        private IStockRepository _repository;

      public StockManger()
        {
            _repository=new StockRepository();
          
        }

        public StockManger(IStockRepository repository)
        {
            _repository = repository;
        }
        public bool Add(StockHeader entity)
        {
           return _repository.Add(entity);
            
        }

        public bool Add(ICollection<StockHeader> entities)
        {
           return _repository.Add(entities);
        }

        public bool Update(StockHeader entity)
        {
           return _repository.Update(entity);
        }

        public bool Update(ICollection<StockHeader> entities)
        {
            return _repository.Update(entities);
        }

        public bool Remove(long id)
        {
           return _repository.Remove(GetById(id));
        }

        public StockHeader GetById(long id, params Expression<Func<StockHeader, object>>[] includes)
        {
           return _repository.GetFirstOrDefault(c => c.Id == id,c=>c.StockDetails);
        }

        //public StockHeader GetById(long id)
        //{
        //    return GetById(id);
        //}

        public ICollection<StockHeader> GetAll()
        {
           return _repository.GetAll();
        }

        public ICollection<StockHeader> Get(Expression<Func<StockHeader, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
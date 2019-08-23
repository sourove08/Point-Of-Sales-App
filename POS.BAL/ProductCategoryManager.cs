using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using POS.DAL;
using POS.Models;
using POS.Models.Interfaces;

namespace POS.BAL
{
    public class ProductCategoryManager:IProductCategoryManager
    {
        private ProductCategoryRepository _repository;

       public ProductCategoryManager()
        {
            _repository=new ProductCategoryRepository();
        }
        public bool Add(ProductCategory productCategory)
        {
           return _repository.Add(productCategory);
        }

        public bool Add(ICollection<ProductCategory> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductCategory productCategory)
        {
            return _repository.Update(productCategory);
        }

        public bool Update(ICollection<ProductCategory> entities)
        {
            throw new NotImplementedException();
        }

        public bool Remove(long id)
        {
            return _repository.Remove(GetById(id));
        }

        public ProductCategory GetById(long id, params Expression<Func<ProductCategory, object>>[] includes)
        {
            return _repository.GetFirstOrDefault(c => c.Id == id,c=>c.Products);
        }

        public ProductCategory GetById(long id)
        {
            return GetById(id);
        }

        public ICollection<ProductCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public ICollection<ProductCategory> Get(Expression<Func<ProductCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
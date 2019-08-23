using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Security.Cryptography;
using POS.DAL;
using POS.Models;
using POS.Models.Interfaces;

namespace POS.BAL
{
    public class ProductManager:IProductManager
    {
        private IProductRepository _repository;

        public ProductManager()
        {
            _repository=new ProductRepository();
        }

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }
        public bool Add(Product product)
        {
            if (!ProductGetByCode(product.Code))
            {
                return _repository.Add(product);
            }
            else
            {
                throw new Exception("Not to be Inserted !!Already Have this product Code!");
            }
           
        }

        public bool Add(ICollection<Product> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {

            if (!ProductGetByCode(product.Code))
            {
                return _repository.Update(product);
            }
            else
            {
                throw new Exception("Not to be Updated!!Already Have this product Code!");
            }
        }

        public bool Update(ICollection<Product> entities)
        {
            throw new NotImplementedException();
        }

        public bool Remove(long id)
        {
            var product = GetById(id);
            if (product==null)
            {
                return false;
            }

            return _repository.Remove(product);
        }

        public Product GetById(long id, params Expression<Func<Product, object>>[] includes)
        {
            return _repository.GetFirstOrDefault(c => c.Id == id,c=>c.Category);
        }

        public bool ProductGetByCode(string Code)
        {
           Product p=_repository.GetAll().ToList().Find(m => m.Code == Code);
            if (p!=null)
            {
                return true;
            }
            return false;
        }

        public ICollection<Product> GetAll()
        {
            return _repository.GetProductsWithCategory().ToList();
           
        }

        public ICollection<Product> Get(Expression<Func<Product, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public ICollection<Product> GetProductsByCategory(long categoryId)
        {
            var products = _repository.GetAll().AsQueryable().Where(p => p.CategoryId == categoryId);
            return products.ToList();
        }
    }
}
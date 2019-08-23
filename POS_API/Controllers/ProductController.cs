using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POS.BAL;
using POS.Models;
using POS.Models.Interfaces;

namespace POS_API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductManager _productManager;

        
        
        public ProductController()
        {
            _productManager=new ProductManager();
        }

       public IHttpActionResult getProducts()
        {
            var products=_productManager.GetAll().Select(p=>new {p.Id,p.Code,p.Name,p.CategoryId,CategoryName=p.Category.Name}).ToList();
           if (products==null||!products.Any())
           {
              return NotFound();
           }
           return Ok(products);
        }

        public IHttpActionResult GetProduct(long id)
        {
            Product product = _productManager.GetById(id);
            var p = new {product.Id,product.Code,product.Name,product.CategoryId};
           return Ok(p);
        }

        public Product PostProduct(Product product)
        {
           bool isSaved=_productManager.Add(product);
            if (isSaved)
            {
                return product;
            }
            return null;
        }

        public Product PutProduct(Product product,long id)
        {
            product.Id = id;
            bool isSaved = _productManager.Update(product);
            if (isSaved)
            {
                return product;
            }
            return null;
        }

        public IHttpActionResult GetProductsByCategory(long categoryId)
        {
            var products = _productManager.GetProductsByCategory(categoryId).Select(p=>new {p.Id,p.Code,p.Name,p.CategoryId});
            return Ok(products);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using POS.BAL;
using POS.Models;
using POS.Models.Interfaces;
using POS.Models.ViewModels;

namespace FirstMvcApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
     
        private IProductManager productManager;

        public ProductController()
        {
            productManager=new ProductManager();
        }

        public static List<ProductCategory> GetProductCategories()
        {
            ProductCategoryManager aManager=new ProductCategoryManager();
            return aManager.GetAll().ToList();
        }

        // GET: /Product/
       //[AllowAnonymous]
        public ActionResult Index()
        {
            var products = productManager.GetAll();
            return View(products.ToList());
        }

        // GET: /Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        
        public ActionResult Create()
        {
            ProductCreateViewModel model=new ProductCreateViewModel();
            model.ProductCategoryLookUp= new SelectList(GetProductCategories(), "Id", "Name");
            model.Products = productManager.GetAll();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
    
        public ActionResult Create(ProductCreateViewModel model)
        {
            //var product = Mapper.Map<Product>(model);
            Product product = new Product()
            {
                Name = model.Name,
                Code = model.Code,
                CategoryId = model.CategoryId
            };
            try
            {
                if (ModelState.IsValid)
                {
                    productManager.Add(product);
                    //return RedirectToAction("Index");
                    ViewBag.message = "Product Added Sucessfully";
                }

               
            }
            catch (Exception ex)
            {

                ViewBag.message = ex.Message;
            }
            model.ProductCategoryLookUp = new SelectList(GetProductCategories(), "Id", "Name");
            model.Products = productManager.GetAll();
            return View(model);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(GetProductCategories(), "Id", "Name", product.CategoryId);
            
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Code,Name,CategoryId")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productManager.Update(product);
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {

                ViewBag.message = ex.Message;
            }
            ViewBag.CategoryId = new SelectList(GetProductCategories(), "Id", "Code", product.CategoryId);
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productManager.GetById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            productManager.Remove(id);
            return RedirectToAction("Index");
        }
       
        public JsonResult GetProductByCategory(long categoryId)
        {
          var products=productManager.GetProductsByCategory(categoryId);
            var productJsonData = products.Select(p => new {p.Id, p.Name, p.Code, p.CategoryId});
            return Json(productJsonData, JsonRequestBehavior.AllowGet);

        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        [Route("Product/Search/{Code}/{Name}")]
        public ActionResult Search(string code, string name)
        {
            var products = productManager.Get(p => p.Code.Contains(code) && p.Name.Contains(name));
            return View(model:products);
        }
    }
}

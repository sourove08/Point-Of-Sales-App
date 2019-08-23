using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.BAL;
using POS.Models;
using POS.Models.Interfaces;

namespace FirstMvcApp.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private IStockManager _stockManager;
        private IProductCategoryManager _productCategoryManager;

      public StockController()
        {
            _stockManager=new StockManger();
          _productCategoryManager=new ProductCategoryManager();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Save()
        {
            var productCategories = _productCategoryManager.GetAll();
            ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        public ActionResult Save(StockHeader stockHeader)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _stockManager.Add(stockHeader);
                if (isSaved)
                {
                    ViewBag.message = "Stock saved sucessfully";
                }
            }
            var productCategories = _productCategoryManager.GetAll();
            ViewBag.ProductCategories = new SelectList(productCategories, "Id", "Name");
            return View(stockHeader);
        }
        
        //[HttpGet]
        //public ActionResult SaveStocks()
        //{
        //    string mesg = "Saved Sucessfully";
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SaveStocks(StockHeader stockHeader)
        //{
        //    return View(stockHeader);
        //}
   }
}
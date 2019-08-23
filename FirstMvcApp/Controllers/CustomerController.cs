using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using POS.BAL;
using POS.Models;
using POS.Models.Database;

namespace FirstMvcApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Customer aCustomer=new Customer();
            return View(aCustomer);
        }

        [HttpPost]
       public ActionResult Index(Customer aCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerManager aManager = new CustomerManager();
                    if (aManager.Insert(aCustomer))
                    {
                        ViewBag.message = "Saved sucessfully!!";
                    }
               
                }
                catch (Exception exp)
                {

                   ModelState.AddModelError("",exp.Message);
                }
            
            }
            
         return View(aCustomer);
        }


        public ActionResult Edit(int? id)
        {

            Customer aCustomer = CustomerGetById(id);
            return View(aCustomer);
        }

        [HttpPost]
        public ActionResult Edit(Customer aCustomer)
        {
            PosDbContext db = new PosDbContext();
            Customer existingCustomer = db.Customers.Find(aCustomer.id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = aCustomer.Name;
                existingCustomer.Email = aCustomer.Email;
                existingCustomer.Address = aCustomer.Address;
               
            }
            if (db.SaveChanges()>0)
            {
                ViewBag.message = "Customer Updated Sucessfully";
            }

            return View(existingCustomer);
        }

        public ActionResult Search()
        {
            PosDbContext db = new PosDbContext();
            return View(db.Customers);
        }
        private Customer CustomerGetById(int? id)
        {
            PosDbContext db = new PosDbContext();
            foreach (Customer aCustomer in db.Customers)
            {
                if (aCustomer.id == id)
                {
                    return aCustomer;
                }
            }
            return null;
        }
    }
}
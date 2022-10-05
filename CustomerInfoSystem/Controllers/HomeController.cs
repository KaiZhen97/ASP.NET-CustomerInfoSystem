using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CustomerInfoSystem.Models;

namespace CustomerInfoSystem.Controllers
{
    public class HomeController : Controller
    {
        dbCustomerEntities db = new dbCustomerEntities();
        // GET: Home
        public ActionResult Index()
        {
            var customer = db.Customer.OrderBy(m => m.Id).ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer vCustomer)
        {
            db.Customer.Add(vCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var customer = db.Customer.Where(m => m.Id == Id).FirstOrDefault();
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var customer = db.Customer.Where(m => m.Id == Id).FirstOrDefault();
            return View(customer);
        }

        public ActionResult Edit(Customer vCustomer)
        {
            int Id = vCustomer.Id;
            var customer = db.Customer.Where(m => m.Id == Id).FirstOrDefault();
            customer.Name = vCustomer.Name;
            customer.Phone_Number = vCustomer.Phone_Number;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
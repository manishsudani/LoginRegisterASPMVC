using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Online.Controllers.Helper;
using Online.Models;

namespace Online.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        TravelExpertsEntities cus = new TravelExpertsEntities();
        public ActionResult Customer()
        {
            
            return View(cus.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer c = cus.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            c.Password = "";
            return View(c);
        
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer cust)
        {
            try
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    cust.Password = PasswordHelper.GetHash(sha256Hash, cust.Password);
                }
                // TODO: Add update logic here
                cus.Entry(cust).State = EntityState.Modified;
                cus.SaveChanges();
                return RedirectToAction("Customer");
            }     
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

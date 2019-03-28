using Online.Models;
using Online.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Security.Cryptography;
using Online.Controllers.Helper;

namespace Online.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoCache]
        public ActionResult Login(LoginVM user)
        {
            // To acces data using LINQ
            TravelExpertsEntities userdt = new TravelExpertsEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        user.Password = PasswordHelper.GetHash(sha256Hash, user.Password);
                    }
                    var q = userdt.Customers.Where(m => m.UserName == user.UserName && m.Password == user.Password).ToList();

                    if (q.Count > 0)
                    {
                        if (q.FirstOrDefault() != null)
                        {
                            Session["CustomerId"] = q.FirstOrDefault().CustomerId;
                            Session["Username"] = q.FirstOrDefault().UserName;
                            return RedirectToAction("Index", "BookingsVM");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
                catch (Exception)
                {
                }
            }
            return View(user);
        }
    }
    
}
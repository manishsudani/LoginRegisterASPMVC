using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Online.Models;



namespace Online.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public class HomeController : Controller
    {
        public object ses;
        private TravelExpertsEntities db = new TravelExpertsEntities();
   

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer reg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(reg);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Customers
                               where userlist.UserName == reg.UserName && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.CustomerId,
                                   userlist.UserName
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["CustomerId"] = details.FirstOrDefault().CustomerId;
                    Session["Username"] = details.FirstOrDefault().UserName;
                    return RedirectToAction("Index", "BookingsVM");
                }
            }
            else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
            return View(reg);
        }
        [NoCache]
        public ActionResult LogOut()
            {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request

            return RedirectToAction("Index");
        }
    }
}
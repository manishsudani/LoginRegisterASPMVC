using Online.Models;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Online.Controllers.Helper;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

namespace Online.Controllers
{
    public class RegisterVMController : Controller
    {
        private TravelExpertsEntities rg = new TravelExpertsEntities();
        // GET: RegisterVM
        public ActionResult Register()
        {
            ViewBag.Province = GetProvincesList();
            ViewBag.State = GetStatesList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        user.Password = PasswordHelper.GetHash(sha256Hash, user.Password);
                    }
                    //user.Password = PasswordHelper.GetHash(user.Password, "SHA512");
                    var usernames = rg.Customers.Select(c => c.UserName).ToList();
                    var emails = rg.Customers.Select(c => c.CustEmail).ToList();
                    bool exists = false;
                    foreach (var item in usernames)
                    {
                        if (user.UserName == item)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (user.CustEmail == "" || user.CustEmail == null) goto check;
                    foreach (var item in emails)
                    {
                        if (user.CustEmail == item)
                        {
                            exists = true;
                            break;
                        }
                    }

                    check: if (!exists)
                    {
                        rg.Customers.Add(user);
                        rg.SaveChanges();
                        return RedirectToAction("Registered");
                    }
                    else
                    {
                        ViewBag.repeatedusermsg = "Username or email address already registered.";
                        ViewBag.Province = GetProvincesList();
                        ViewBag.State = GetStatesList();
                        return View();
                    }                   

                }
            }
            catch (DbEntityValidationException dbEx)
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

            ViewBag.Province = GetProvincesList();
            ViewBag.State = GetStatesList();
            return View();
        }

        public ActionResult Registered()
        {
            return View();
        }

        public static IEnumerable<SelectListItem> GetProvincesList()
        {
            List<string> names = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/provinces.txt")).ToList();
            List<string> abbr = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/abbrev.txt")).ToList();
            List<ProSta> provs = new List<ProSta>();
            for (var i = 0; i < names.Count; i++)
            {
                ProSta p = new ProSta();
                p.Name = names[i];
                p.Abbreviation = abbr[i];
                provs.Add(p);
            }
            IList<SelectListItem> provinces = new List<SelectListItem> { };
            foreach (ProSta p in provs)
            {
                provinces.Add(new SelectListItem { Text = p.Name, Value = p.Abbreviation });
            }
            return provinces;
        }

        public static IEnumerable<SelectListItem> GetStatesList()
        {
            List<string> names = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/states.txt")).ToList();
            List<string> abbr = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/abbstates.txt")).ToList();
            List<ProSta> st = new List<ProSta>();
            for (var i = 0; i < names.Count; i++)
            {
                ProSta s = new ProSta();
                s.Name = names[i];
                s.Abbreviation = abbr[i];
                st.Add(s);
            }
            IList<SelectListItem> states = new List<SelectListItem> { };
            foreach (ProSta s in st)
            {
                states.Add(new SelectListItem { Text = s.Name, Value = s.Abbreviation });
            }
            return states;
        }

        internal class ProSta
        {
            public string Name { get; set; }
            public string Abbreviation { get; set; }
        }


    }
}
using Online.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Online.Models.ViewModel;

namespace Online.Controllers.ViewModel
{
    public class BookingsVMController : Controller
    {
        // GET: BookingsVM
        
        public ActionResult Index()
        {
            TravelExpertsEntities bks = new TravelExpertsEntities();
            List<BookingsVM> BookingsVMList = new List<BookingsVM>();

            var bookingList = (from b in bks.Bookings
                              join c in bks.Customers on b.CustomerId equals c.CustomerId
                              join p in bks.Packages on b.PackageId equals p.PackageId
                              join d in bks.BookingDetails on b.BookingId equals d.BookingId
                              select new {b.CustomerId, b.BookingDate, b.BookingNo, b.TravelerCount, c.CustFirstName, c.CustLastName, p.PkgName, p.PkgBasePrice, d.BasePrice, d.Description }).ToList();

            foreach (var item in bookingList)

            {

                BookingsVM objcvm = new BookingsVM(); // ViewModel

                objcvm.CustomerId = item.CustomerId;

                objcvm.BookingDate = item.BookingDate;

                objcvm.BookingNo = item.BookingNo;

                objcvm.TravelerCount = item.TravelerCount;

                objcvm.CustFirstName = item.CustFirstName;

                objcvm.CustLastName = item.CustLastName;

                objcvm.PkgName = item.PkgName;

                objcvm.PkgBasePrice = item.PkgBasePrice;

                objcvm.BasePrice = item.BasePrice;

                objcvm.Description = item.Description;

                BookingsVMList.Add(objcvm);

            }

            return View(BookingsVMList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Online.Models;

namespace Online.Models.ViewModel
{
    public class BookingsVM
    {
       
        public int Id { get; set; }
        [DisplayName("Booking Date")]
        public Nullable<System.DateTime> BookingDate { get; set; }

        public int? CustomerId { get; set; }
        [DisplayName("Booking Number")]
        public string BookingNo { get; set; }

        [DisplayName("Number of Travelers")]
        public Nullable<double> TravelerCount { get; set; }

        [DisplayName("First Name")]
        public string CustFirstName { get; set; }

        [DisplayName("Last Name")]
        public string CustLastName { get; set; }

        [DisplayName("Package Name")]
        public string PkgName { get; set; }

        [DisplayName("Package Price")]
        public decimal PkgBasePrice { get; set; }

        [DisplayName("Invidual Product")]
        public string Description { get; set; }

        [DisplayName("Price")]
        public Nullable<decimal> BasePrice { get; set; }

        
    }
}
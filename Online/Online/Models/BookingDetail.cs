//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public Nullable<double> ItineraryNo { get; set; }
        public Nullable<System.DateTime> TripStart { get; set; }
        public Nullable<System.DateTime> TripEnd { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public Nullable<decimal> BasePrice { get; set; }
        public Nullable<decimal> AgencyCommission { get; set; }
        public Nullable<int> BookingId { get; set; }
        public string RegionId { get; set; }
        public string ClassId { get; set; }
        public string FeeId { get; set; }
        public Nullable<int> ProductSupplierId { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}

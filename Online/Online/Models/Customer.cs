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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CustFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CustLastName { get; set; }

        [DisplayName("Address")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string CustAddress { get; set; }

        [DisplayName("City")]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string CustCity { get; set; }

        [DisplayName("Province")]
        [Required]
        [StringLength(2)]
        public string CustProv { get; set; }

        [DisplayName("Postal Code")]
        [Required]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Please enter a Valid Postal code with all Upper Case Letters")]
        [StringLength(30, MinimumLength = 3)]
        public string CustPostal { get; set; }

        [DisplayName("Country")]
        [Required]
        public string CustCountry { get; set; }

        [DisplayName("Home Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CustHomePhone { get; set; }

        [DisplayName("Business Phone")]
        public string CustBusPhone { get; set; }

        [DisplayName("Email")]
        public string CustEmail { get; set; }

        public Nullable<int> AgentId { get; set; }

        [DisplayName("Username")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
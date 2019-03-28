using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Online.Models.ViewModels
{
    public class RegistrationVM
    {
        [Key]
        public int CustomerId { get; set; }
        [DisplayName("First Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CustFirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Last Name")]
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
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]|[0-9]{5}", ErrorMessage = "Please enter a valid Postal Code.")]
        //[StringLength(30, MinimumLength = 3)]
        public string CustPostal { get; set; }

        [DisplayName("Country")]
        [Required]
        //[StringLength(30, MinimumLength = 3)]
        public string CustCountry { get; set; }

        [DisplayName("Home Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CustHomePhone { get; set; }

        [DisplayName("Business Phone (Optional)")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string CustBusPhone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Not a valid email address")]
        public string CustEmail { get; set; }

        public Nullable<int> AgentId { get; set; }

        [DisplayName("Username")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
            ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
            MinRequiredPasswordLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string Password { get; set; }

        [NotMapped]
        [ScriptIgnore]
        [Required(ErrorMessage = "Please Enter Confirm Password !!!")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password must match with Password !!!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
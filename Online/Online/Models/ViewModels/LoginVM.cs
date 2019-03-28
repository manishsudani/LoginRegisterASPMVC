using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Online.Models.ViewModels
{
    public class LoginVM
    {   [Key]
        public int? CustomerId { get; internal set; }

        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "User Name")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MembershipPassword(
            MinRequiredNonAlphanumericCharacters = 1,
            MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
            ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
            MinRequiredPasswordLength = 6 )]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
   
       
    }
}
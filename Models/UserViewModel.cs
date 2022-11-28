using System.ComponentModel.DataAnnotations;

namespace UserRegistration3.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }




        [Required]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }





        [Required]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string? EmailId { get; set; }





        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile number is not valid")]
        [Display(Name = "Mobile Number")]
        public string? MobileNumber { get; set; }

        public string? Address { get; set; }




        [Required]
        [Range(18, 60)]
        public int? Age { get; set; }



        [Required]
        public string? Gender { get; set; }

        //25 Nov 2022
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        //public List<string> GenderOpitons { get; set;}

        public bool IsTermsAndConditionsChecked { get; set; }


        public string Physicallychallanged { get; set; }
    }
}

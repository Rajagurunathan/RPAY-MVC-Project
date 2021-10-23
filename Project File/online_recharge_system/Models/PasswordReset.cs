using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace online_recharge_system.Models
{
    public class PasswordReset
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter the email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"
            , ErrorMessage = "Not a Valid Mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string password { get; set; }

        [Display(Name = "Confirm new password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string c_password { get; set; }


        [Display(Name = "Verify Otp")]
        [Required(ErrorMessage = "Enter Valid Otp")]
        public string otp { get; set; }

    }
}
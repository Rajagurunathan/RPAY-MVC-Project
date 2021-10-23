using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_recharge_system.Models
{
    public class UserRegistration
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the name")]
        public string name { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter the mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string phone_number { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter the email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"
            , ErrorMessage = "Not a Valid Mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }

        [Display(Name = "DATE OF BIRTH")]
        [Required(ErrorMessage = "Please enter the DOB")]
        [RegularExpression(@"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$",
            ErrorMessage = "Not a Valid Date")]
        [DataType(DataType.Date)]
        public string dob { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter the city")]
        public string city { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter the state")]
        public string state { get; set; }

        [Display(Name = "Pincode")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[1-9][0-9]{5}$",
            ErrorMessage = "Invaild Indian Pincode")]
        [Required(ErrorMessage = "Please enter valid pincode")]
        public string pincode { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string password { get; set; }

        [Display(Name = "Confirm new password")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string c_password { get; set; }

       // public long balance { get; set; }

    }
}
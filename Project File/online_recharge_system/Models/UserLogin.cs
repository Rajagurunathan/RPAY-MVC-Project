using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace online_recharge_system.Models
{
    public class UserLogin
    {
        public long userid { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Please enter the email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"
            , ErrorMessage = "Not a Valid Mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        [Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_recharge_system.Models
{
    public class SupportEmail 
    {
        // [Display(Name = "Email")]
        // [Required(ErrorMessage = "Please enter the email")]
        // [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"
        //     , ErrorMessage = "Not a Valid Mail")]
        // [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string to { get; set; }

        public string subject { get; set; }

        public string body { get; set; }

    }
}
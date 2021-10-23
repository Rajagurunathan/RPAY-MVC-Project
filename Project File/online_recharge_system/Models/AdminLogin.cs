using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace online_recharge_system.Models
{
    public class AdminLogin 
    {
        public long admin_id { get; set; }
        [Required(ErrorMessage = "Please enter the username")]
        [Display(Name = "USER NAME")]
        public string admin_name { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        [Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        public string admin_password { get; set; }
    }
}
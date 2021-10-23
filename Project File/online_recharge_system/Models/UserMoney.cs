using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace online_recharge_system.Models
{
    public class UserMoney
    {
        [Display(Name = "CREDIT CARD NUMBER")]
        // [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "INVALID CC CARD")]
        [RegularExpression(@"^4[0-9]{12}(?:[0-9]{3})?$",ErrorMessage = "Invalid VISA")]
        [Required(ErrorMessage = "ENTER VALID CC")]
        public long cc { get; set; }

        [Display(Name = "CCV")]
        [DataType(DataType.Password)]
        // [RegularExpression(@"^[0-9]{3, 4}$",ErrorMessage = "INVALID CCV")]
        [Required(ErrorMessage = "ENTER VALID CCV")]
        public long ccv { get; set; }

        [Display(Name = "EXPIRY")]
        [Required(ErrorMessage = "EXP MM/YYYY")]
        [RegularExpression(@"^(0[1-9]|1[0-2]|[1-9])\/(1[4-9]|[2-9][0-9]|20[1-9][1-9])$"
        ,ErrorMessage = "Period Invalid")]
        [DataType(DataType.DateTime)]
        public string exp { get; set; }

        [Display(Name = "BALANCE")]
        [Required(ErrorMessage = "ENTER AMOUNT")]
        [DataType(DataType.Currency)]
        public long addamount { get; set; }

    }
}
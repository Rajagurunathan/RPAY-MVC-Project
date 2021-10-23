using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_recharge_system.Models
{
    public class RechargeClass
    {

        public string PhoneNumber
        {
            get; set;
        }

        public string NetworkOperator
        {
            get; set;
        }

        public string PlanCategory
        {
            get; set;
        }

        public string PlanName
        {
            get; set;
        }

        public int Amount
        {
            get; set;
        }
    }
}
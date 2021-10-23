using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online_recharge_system.Models
{
    public class ViewModel
    {
        public User user
        {
            get; set;
        }
        public Transaction transact
        {
            get; set;
        }

        public Plan plan
        {
            get; set;
        }

        public Operator op
        {
            get; set;
        }
    }
}
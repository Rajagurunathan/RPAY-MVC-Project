//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminDashBoard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int transaction_id { get; set; }
        public Nullable<System.DateTime> date_time { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> plan_id { get; set; }
        public Nullable<int> operator_id { get; set; }
        public string phone_number { get; set; }
        public string status { get; set; }
    
        public virtual Operator Operator { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual User User { get; set; }
    }
}

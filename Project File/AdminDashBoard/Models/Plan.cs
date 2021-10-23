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
    
    public partial class Plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int plan_id { get; set; }
        public string plan_name { get; set; }
        public string plan_description { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> validity { get; set; }
        public string plan_type { get; set; }
        public Nullable<int> operator_id { get; set; }
    
        public virtual Operator Operator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S360Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHQ_ChequeDepositsStatement_Details
    {
        public decimal Statement_ID { get; set; }
        public Nullable<System.DateTimeOffset> EnteredOn { get; set; }
        public Nullable<decimal> EnteredBy { get; set; }
        public Nullable<decimal> Login_ID { get; set; }
        public string AccountNo { get; set; }
        public bool IsActive { get; set; }
        public Nullable<decimal> CancelledBy_ID { get; set; }
    }
}
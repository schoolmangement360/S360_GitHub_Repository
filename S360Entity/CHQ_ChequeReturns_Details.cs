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
    
    public partial class CHQ_ChequeReturns_Details
    {
        public decimal ChqReturn_ID { get; set; }
        public Nullable<decimal> Cheque_ID { get; set; }
        public Nullable<System.DateTimeOffset> EnteredOn { get; set; }
        public Nullable<decimal> EnteredBy { get; set; }
        public Nullable<decimal> Login_ID { get; set; }
        public Nullable<System.DateTime> ReturnedDate { get; set; }
    
        public virtual CHQ_Cheques_Master CHQ_Cheques_Master { get; set; }
    }
}

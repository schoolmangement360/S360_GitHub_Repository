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
    
    public partial class CHQ_Cheques_Master_Temp
    {
        public decimal Cheque_ID { get; set; }
        public Nullable<decimal> Student_ID { get; set; }
        public Nullable<short> Section_ID { get; set; }
        public Nullable<System.DateTimeOffset> EnteredOn { get; set; }
        public Nullable<decimal> EnteredBy { get; set; }
        public Nullable<decimal> Login_ID { get; set; }
        public Nullable<System.DateTime> InwardDate { get; set; }
        public string ChequeNo { get; set; }
        public string Bank { get; set; }
        public Nullable<decimal> ChqAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> ChqStatus_ID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}

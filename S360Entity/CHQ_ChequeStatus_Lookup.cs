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
    
    public partial class CHQ_ChequeStatus_Lookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHQ_ChequeStatus_Lookup()
        {
            this.CHQ_Cheques_Master = new HashSet<CHQ_Cheques_Master>();
            this.CHQ_DeletedCheque_Details = new HashSet<CHQ_DeletedCheque_Details>();
        }
    
        public byte ChqStatus_ID { get; set; }
        public string StatusName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHQ_Cheques_Master> CHQ_Cheques_Master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHQ_DeletedCheque_Details> CHQ_DeletedCheque_Details { get; set; }
    }
}
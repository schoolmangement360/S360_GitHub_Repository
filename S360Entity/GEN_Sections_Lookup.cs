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
    
    public partial class GEN_Sections_Lookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GEN_Sections_Lookup()
        {
            this.STUD_StudentAcademic_Details = new HashSet<STUD_StudentAcademic_Details>();
        }
    
        public byte Section_Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUD_StudentAcademic_Details> STUD_StudentAcademic_Details { get; set; }
    }
}

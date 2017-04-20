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
    
    public partial class STUD_StudentAcademic_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUD_StudentAcademic_Details()
        {
            this.STUD_DetainingOrPromotions_Details = new HashSet<STUD_DetainingOrPromotions_Details>();
            this.STUD_DetainingOrPromotions_Details1 = new HashSet<STUD_DetainingOrPromotions_Details>();
            this.STUD_Students_Master1 = new HashSet<STUD_Students_Master>();
        }
    
        public decimal AcademicDet_ID { get; set; }
        public string RegNo { get; set; }
        public decimal Student_ID { get; set; }
        public byte Section_ID { get; set; }
        public Nullable<short> Standard_ID { get; set; }
        public Nullable<short> Division { get; set; }
        public Nullable<int> AcademicYearStart { get; set; }
        public Nullable<int> AcademicYearEnd { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    
        public virtual GEN_Sections_Lookup GEN_Sections_Lookup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUD_DetainingOrPromotions_Details> STUD_DetainingOrPromotions_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUD_DetainingOrPromotions_Details> STUD_DetainingOrPromotions_Details1 { get; set; }
        public virtual STUD_Students_Master STUD_Students_Master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUD_Students_Master> STUD_Students_Master1 { get; set; }
    }
}
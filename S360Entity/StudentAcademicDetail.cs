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
    
    public partial class StudentAcademicDetail
    {
        public decimal AcademicDet_ID { get; set; }
        public string RegNo { get; set; }
        public decimal Student_ID { get; set; }
        public Nullable<int> Section_ID { get; set; }
        public Nullable<short> Standard_ID { get; set; }
        public Nullable<short> Division { get; set; }
        public Nullable<int> AcademicYearStart { get; set; }
        public Nullable<int> AcademicYearEnd { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}

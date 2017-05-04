using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class PromoteStudentModel : StudentBaseModel
    {
        [System.ComponentModel.Browsable(false)]
        public short StandardID { get; set; }
        public string Standard { get; set; }
        [System.ComponentModel.Browsable(false)]
        public long LastAcademicDetID { get; set; }
        [System.ComponentModel.Browsable(false)]
        public short SatusID { get; set; }
        public string Division { get; set; }
        [System.ComponentModel.Browsable(false)]
        public short SectionId { get; set; }
        public string Section { get; set; }
    }
}

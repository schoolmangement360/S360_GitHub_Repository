using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class StudentBaseModel
    {
        [System.ComponentModel.Browsable(false)]
        public long StudentId { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Father { get; set; }
    }
}

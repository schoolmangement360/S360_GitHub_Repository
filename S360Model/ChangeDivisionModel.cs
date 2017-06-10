using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class ChangeDivisionModel : StudentBaseModel
    {
        public string OldDivision { get; set; }
        public string NewDivision { get; set; }
        public string Fullname
        {
            get { return Name + " " + Father + " " + SurName; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class DetainStudentModel : StudentBaseModel
    {
        [System.ComponentModel.Browsable(false)]
        public short SectionId { get; set; }
        public string Section { get; set; }
        [System.ComponentModel.Browsable(false)]
        public short StandardID { get; set; }
        public string Standard { get; set; }

        private UserBaseModel _user = null;
        public UserBaseModel User
        {
            get
            {
                if (_user == null)
                    _user = new UserBaseModel();
                return _user;
            }
            set { _user = value; }
        }
    }
}

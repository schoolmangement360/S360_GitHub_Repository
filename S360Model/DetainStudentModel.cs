using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class DetainStudentModel : PromoteStudentModel
    {
        public short SectionId { get; set; }

        public string Section { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public bool IsDetain { get; set; }

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

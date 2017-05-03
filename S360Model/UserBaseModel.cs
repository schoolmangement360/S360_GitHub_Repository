using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class UserBaseModel
    {
        public decimal UserID { get; set; }
        public decimal LoginID { get; set; }
        public string Username { get; set; }
        public short SystemRoleID { get; set; }
    }
}

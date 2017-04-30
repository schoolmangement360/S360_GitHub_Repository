using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class LoginModel
    {
        public decimal UserID { get; set; }
        public decimal LoginID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public bool IsLogin { get; set; }
    }
}

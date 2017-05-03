using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S360Model
{
    public class LoginModel : UserBaseModel
    {
        public string Password { get; set; }
        public string Message { get; set; }
        public bool IsLogin { get; set; }
    }
}

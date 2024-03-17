using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }

        public LoginRequest()
        {
            email = string.Empty;
            password = string.Empty;
        }

    }
}

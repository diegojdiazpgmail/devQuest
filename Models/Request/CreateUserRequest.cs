using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class CreateUserRequest
    {
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public int discordId { get; set; }
        public string discordName { get; set; }
        public string userRole { get; set; }
        public string discordMemberSince { get; set; }


    }
}

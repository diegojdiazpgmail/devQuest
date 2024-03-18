using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserEntity
    {
        public int userId { get; set; }
        public string userGuid { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string discordId { get; set; }
        public string discordName { get; set; }
        public DateTime discordMemberSince { get; set; }
        public DateTime createdAt { get; set; }
        public bool isValid { get; set; }

        public UserEntity()
        {
            userId=0;
            email=string.Empty;
            password=string.Empty;
            role=string.Empty;
            discordId=string.Empty;
            discordName=string.Empty;
            discordMemberSince=DateTime.MinValue;
            createdAt=DateTime.MinValue;
            userGuid=string.Empty;
            isValid=false;
            userName=string.Empty;
        }

    }
}

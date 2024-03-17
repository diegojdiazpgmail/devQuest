using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class SaveUserContestRequest
    {
        public string userGuid { get; set; }
        public string contestGuid { get; set; }

    }
}

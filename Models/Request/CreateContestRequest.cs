using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class CreateContestRequest
    {
        public string contestName { get; set; }
        public string contestDescription { get; set; }
        public DateTime contestStartsAt { get; set; }
        public DateTime contestEndsAt { get; set; }
        public string contestOwnerEmail { get; set; }
        public bool contestStatus { get; set; }
        public int maxNumber { get; set; }
        public int contestantNumber { get; set; }
    }
}

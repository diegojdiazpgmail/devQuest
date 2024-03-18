using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContestEntity
    {
        public int contestId { get; set; }
        public string contestGuid { get; set; }
        public string contestName { get; set; }
        public string contestDescription { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool contestStatus { get; set; }
        public string mensaje { get; set; }
        public int maxNumber { get; set; }
        public int contestNumber { get; set; }

        public ContestEntity()
        {
            contestId = 0;
            contestName = string.Empty;
            startsAt = DateTime.MinValue;
            endsAt = DateTime.MinValue;
            contestStatus = false;
            contestGuid = string.Empty;
            contestDescription = string.Empty;
            maxNumber=0;
            contestNumber=0;
        }
    }
}

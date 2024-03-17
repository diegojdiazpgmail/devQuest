using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class ContestResponse
    {
        public ContestEntity contest { get; set; }
        public List<UserEntity> participants { get; set; }

        public ContestResponse()
        {
            contest= new ContestEntity();
            participants= new List<UserEntity>();
        }
    }
}

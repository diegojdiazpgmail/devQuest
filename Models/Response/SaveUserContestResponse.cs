using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class SaveUserContestResponse
    {

        public UserEntity user { get; set; }
        public TransactionModel transaction { get; set; }
        public string contestGuid { get; set; }
    }
}

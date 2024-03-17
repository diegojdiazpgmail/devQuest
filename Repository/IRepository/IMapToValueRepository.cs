using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IMapToValueRepository
    {
        UserEntity MapUser(SqlDataReader dr);
        ContestEntity MapContest(SqlDataReader dr);
        TransactionModel MapResponseTransaction(SqlDataReader dr);
    }
}

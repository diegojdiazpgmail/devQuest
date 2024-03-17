using Entities;
using Models;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IContestService
    {
        Task<ContestEntity> CreateContest(CreateContestRequest request);
        Task<ContestEntity> GetContestById(GetByIdRequest request);
        Task<ContestEntity> GetActiveContest();
        Task<List<ContestEntity>> GetContestByStatus(GetByStatusRequest request);
        Task<List<UserEntity>> GetContestUsers(GetByIdRequest request);
        Task<List<ContestEntity>> GetContestHistory();
        Task<TransactionModel> SaveUserContest(SaveUserContestRequest request);
    }
}

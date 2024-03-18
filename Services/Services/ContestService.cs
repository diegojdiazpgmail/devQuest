using Entities;
using Models;
using Models.Request;
using Models.Response;
using Repository.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ContestService : IContestService
    {
        private readonly IContestRepository _contestRepository;
        public ContestService(IContestRepository contestRepository)
        {
            _contestRepository = contestRepository ?? throw new ArgumentNullException(nameof(contestRepository));
        }
        public async Task<ContestEntity> CreateContest(CreateContestRequest request)
        {
            return await _contestRepository.CreateContest(request);

        }
        public async Task<ContestEntity> GetContestById(GetByIdRequest request)
        {
            return await _contestRepository.GetContestById(request);

        }
        public async Task<List<ContestEntity>> GetContestByStatus(GetByStatusRequest request)
        {
            return await _contestRepository.GetContestByStatus(request);

        }
        public async Task<ContestEntity> GetActiveContest()
        {
            return await _contestRepository.GetActiveContest();

        }
        public async Task<List<UserEntity>> GetContestUsers(GetByIdRequest request)
        {
            return await _contestRepository.GetContestUsers(request);

        }
        public async Task<List<ContestEntity>> GetContestHistory()
        {
            return await _contestRepository.GetContestHistory();

        }
        public async Task<SaveUserContestResponse> SaveUserContest(SaveUserContestRequest request)
        {
            return await _contestRepository.SaveUserContest(request);

        }
    }
}

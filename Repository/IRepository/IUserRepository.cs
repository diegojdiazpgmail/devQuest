using Entities;
using Models;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        Task<BaseResponseModel<List<UserEntity>>> getUsers();
        Task<UserEntity> createUser(CreateUserRequest request);
        Task<TransactionModel> UpdateUser(CreateUserRequest request);
        Task<WinnerPickerResponse> WinnerPicker();
    }
}

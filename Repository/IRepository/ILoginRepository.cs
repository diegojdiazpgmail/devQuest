using Entities;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ILoginRepository
    {
        Task<UserEntity> login(LoginRequest request);
    }
}

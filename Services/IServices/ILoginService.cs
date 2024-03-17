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
    public interface ILoginService
    {
        Task<UserEntity> login(LoginRequest loginRequest);
    }
}

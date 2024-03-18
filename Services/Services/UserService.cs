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
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;
        public UserService(IUserRepository usuariosRepository)
        {
            _usuarioRepository = usuariosRepository ?? throw new ArgumentNullException(nameof(usuariosRepository));
        }
        public async Task<BaseResponseModel<List<UserEntity>>> getUsers()
        {
            return await _usuarioRepository.getUsers();
        }
        public async Task<UserEntity> createUser(CreateUserRequest request)
        {
            return await _usuarioRepository.createUser(request);
        }
        public async Task<TransactionModel> UpdateUser(CreateUserRequest request)
        {
            return await _usuarioRepository.UpdateUser(request);
        }
        public async Task<WinnerPickerResponse> WinnerPicker()
        {
            return await _usuarioRepository.WinnerPicker();
        }

    }
}

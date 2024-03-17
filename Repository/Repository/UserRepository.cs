using Entities;
using Models;
using Models.Request;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConfig _configDB;
        private readonly IMapToValueRepository _mapToValue;

        public UserRepository(IDBConfig bDConfig, IMapToValueRepository mapToValue)
        {
            _configDB = bDConfig ?? throw new ArgumentNullException(nameof(bDConfig));
            _mapToValue = mapToValue;
        }
        public async Task<BaseResponseModel<List<UserEntity>>> getUsers()
        {
            BaseResponseModel<List<UserEntity>> respuesta = new();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_getUsers", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    List<UserEntity> usuarios = new List<UserEntity>();
                    UserEntity usu = new UserEntity();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usu = _mapToValue.MapUser(reader);
                            usuarios.Add(usu);

                        }
                    }
                    respuesta.IsExito=true;
                    respuesta.Objeto = usuarios;
                    return respuesta;
                }
            }
        }
        public async Task<UserEntity> createUser(CreateUserRequest request)
        {
            UserEntity respuesta = new UserEntity();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_createUser", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_USER_EMAIL", request.userEmail);
                    cmd.Parameters.AddWithValue("@PTR_USER_NAME", request.userName);
                    cmd.Parameters.AddWithValue("@PTR_USER_PASSWORD", request.userPassword);
                    cmd.Parameters.AddWithValue("@PTR_DISCORD_ID", request.discordId);
                    cmd.Parameters.AddWithValue("@PTR_DISCORD_NAME", request.discordName);
                    cmd.Parameters.AddWithValue("@PTR_USER_ROLE", request.userRole);


                    UserEntity usu = new UserEntity();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta = _mapToValue.MapUser(reader);
                        }
                    }
                    return respuesta;
                }
            }
        }

        public async Task<TransactionModel> UpdateUser(CreateUserRequest request)
        {
            TransactionModel respuesta = new TransactionModel();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_updateUser", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_USER_EMAIL", request.userEmail);
                    cmd.Parameters.AddWithValue("@PTR_USER_NAME", request.userName);
                    cmd.Parameters.AddWithValue("@PTR_USER_PASSWORD", request.userPassword);
                    cmd.Parameters.AddWithValue("@PTR_DISCORD_ID", request.discordId);
                    cmd.Parameters.AddWithValue("@PTR_DISCORD_NAME", request.discordName);
                    cmd.Parameters.AddWithValue("@PTR_USER_ROLE", request.userRole);
                    cmd.Parameters.AddWithValue("@PTR_DISCORD_MEMBER_SINCE", Convert.ToDateTime(request.discordMemberSince));


                    UserEntity usu = new UserEntity();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta = _mapToValue.MapResponseTransaction(reader);
                        }
                    }
                    return respuesta;
                }
            }
        }
    }
}

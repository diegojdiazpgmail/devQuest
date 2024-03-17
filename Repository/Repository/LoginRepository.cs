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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBConfig _configDB;
        private readonly IMapToValueRepository _mapToValue;

        public LoginRepository(IDBConfig bDConfig, IMapToValueRepository mapToValue)
        {
            _configDB = bDConfig ?? throw new ArgumentNullException(nameof(bDConfig));
            _mapToValue = mapToValue;
        }

        public async Task<UserEntity> login(LoginRequest request)
        {
            UserEntity respuesta = new();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_Login", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_USER_EMAIL", request.email);
                    cmd.Parameters.AddWithValue("@PTR_PASSWORD", request.password);
                    UserEntity usuario = new UserEntity();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta=_mapToValue.MapUser(reader);
                        }
                    }

                    return respuesta;
                }
            }
        }

    }
}

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
    public class ContestRepository : IContestRepository
    {

        private readonly IDBConfig _configDB;
        private readonly IMapToValueRepository _mapToValue;

        public ContestRepository(IDBConfig bDConfig, IMapToValueRepository mapToValue)
        {
            _configDB = bDConfig ?? throw new ArgumentNullException(nameof(bDConfig));
            _mapToValue = mapToValue;
        }

        public async Task<ContestEntity> GetContestById(GetByIdRequest request)
        {
            ContestEntity respuesta = new ContestEntity();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_Getcontest", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_GUID", request.id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta=_mapToValue.MapContest(reader);
                        }
                    }

                    return respuesta;
                }
            }
        }
        public async Task<ContestEntity> GetActiveContest()
        {
            ContestEntity respuesta = new ContestEntity();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_GetActiveContest", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta=_mapToValue.MapContest(reader);
                        }
                    }
                    return respuesta;
                }
            }
        }

        public async Task<List<ContestEntity>> GetContestByStatus(GetByStatusRequest request)
        {
            List<ContestEntity> respuesta = new List<ContestEntity>();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pc_Login", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta.Add(_mapToValue.MapContest(reader));
                        }
                    }

                    return respuesta;
                }
            }
        }

        public async Task<ContestEntity> CreateContest(CreateContestRequest request)
        {
            ContestEntity respuesta = new ContestEntity();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_CreateContest", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_NAME", request.contestName);
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_DESCRIPTION", request.contestDescription);
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_START", request.contestStartsAt);
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_ENDS", request.contestEndsAt);
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_STATUS", request.contestStatus);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta=_mapToValue.MapContest(reader);

                        }
                    }

                    return respuesta;
                }
            }
        }

        public async Task<List<UserEntity>> GetContestUsers(GetByIdRequest request)
        {
            List<UserEntity> respuesta = new List<UserEntity>();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_GetContestUsers", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_GUID", request.id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta.Add(_mapToValue.MapUser(reader));
                        }
                    }

                    return respuesta;
                }
            }
        }
        public async Task<TransactionModel> SaveUserContest(SaveUserContestRequest request)
        {
            TransactionModel respuesta = new TransactionModel();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_SaveContestUser", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_USER_GUID", request.userGuid);
                    cmd.Parameters.AddWithValue("@PTR_CONSTEST_GUID", request.contestGuid);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            respuesta=_mapToValue.MapResponseTransaction(reader);
                        }
                    }

                    return respuesta;
                }
            }
        }


        public async Task<List<ContestEntity>> GetContestHistory()
        {
            List<ContestEntity> respuesta = new List<ContestEntity>();
            using (SqlConnection sql = new SqlConnection(_configDB.GetDB()))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.pa_Getcontest", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PTR_CONTEST_GUID", string.Empty);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            respuesta.Add(_mapToValue.MapContest(reader));
                        }
                    }

                    return respuesta;
                }
            }
        }
    }
}

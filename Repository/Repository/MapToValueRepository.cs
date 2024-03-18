using Entities;
using Models;
using Models.Request;
using Models.Response;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository.Repository
{
    public class MapToValueRepository : IMapToValueRepository
    {
        public UserEntity MapUser(SqlDataReader dr)
        {
            UserEntity user = new UserEntity();
            user.userId= dr["USER_ID"] != DBNull.Value ? Convert.ToInt32(dr["USER_ID"].ToString()) : 0;
            user.userGuid= dr["USER_GUID"] != DBNull.Value ? dr["USER_GUID"].ToString() : string.Empty;
            user.email=dr["USER_EMAIL"] != DBNull.Value ? dr["USER_EMAIL"].ToString() : string.Empty;
            user.role=dr["USER_ROLE"] != DBNull.Value ? dr["USER_ROLE"].ToString() : string.Empty;
            user.discordId=dr["DISCORD_ID"] != DBNull.Value ? (dr["DISCORD_ID"].ToString()) : string.Empty;
            user.discordName=dr["DISCORD_NAME"] != DBNull.Value ? dr["DISCORD_NAME"].ToString() : string.Empty;
            user.discordMemberSince=dr["DISCORD_MEMBER_SINCE"] != DBNull.Value ? Convert.ToDateTime(dr["DISCORD_MEMBER_SINCE"].ToString()) : DateTime.MinValue;
            user.createdAt=dr["CREATE_DATE"] != DBNull.Value ? Convert.ToDateTime(dr["CREATE_DATE"].ToString()) : DateTime.MinValue;
            user.isValid=dr["IS_VALID"] != DBNull.Value ? Convert.ToBoolean(dr["IS_VALID"].ToString()) : false;

            return user;
        }
        public ContestEntity MapContest(SqlDataReader dr)
        {
            ContestEntity contest = new ContestEntity();
            contest.contestId= dr["CONTEST_ID"] != DBNull.Value ? Convert.ToInt32(dr["CONTEST_ID"].ToString()) : 0;
            contest.contestGuid= dr["CONTEST_GUID"] != DBNull.Value ? (dr["CONTEST_GUID"].ToString()) : string.Empty;
            contest.contestName= dr["CONTEST_NAME"] != DBNull.Value ? dr["CONTEST_NAME"].ToString() : string.Empty;
            contest.contestDescription= dr["CONTEST_DESCRIPTION"] != DBNull.Value ? dr["CONTEST_DESCRIPTION"].ToString() : string.Empty;
            contest.startsAt= dr["CONTEST_START"] != DBNull.Value ? Convert.ToDateTime(dr["CONTEST_START"].ToString()) : DateTime.MinValue;
            contest.endsAt= dr["CONTEST_ENDS"] != DBNull.Value ? Convert.ToDateTime(dr["CONTEST_ENDS"].ToString()) : DateTime.MinValue;
            contest.contestStatus= dr["CONTEST_STATUS"] != DBNull.Value ? Convert.ToBoolean(dr["CONTEST_STATUS"].ToString()) : false;

            return contest;
        }

        public TransactionModel MapResponseTransaction(SqlDataReader dr)
        {
            TransactionModel transaction = new TransactionModel();
            transaction.Resultado= dr["RESULTADO"] != DBNull.Value ? Convert.ToBoolean(dr["RESULTADO"].ToString()) : false;
            transaction.MensajeResultado= dr["MENSAJE_RESULTADO"] != DBNull.Value ? (dr["MENSAJE_RESULTADO"].ToString()) : string.Empty;

            return transaction;
        }

        public SaveUserContestResponse MapSaveUserContest(SqlDataReader dr)
        {
            SaveUserContestResponse transaction = new SaveUserContestResponse();
            transaction.user=new UserEntity();
            transaction.transaction=new TransactionModel();

            transaction.user.userGuid= dr["USER_GUID"] != DBNull.Value ? (dr["USER_GUID"].ToString()) : string.Empty;
            transaction.user.isValid= dr["IS_VALID"] != DBNull.Value ? Convert.ToBoolean(dr["IS_VALID"].ToString()) : false;
            transaction.user.email= dr["USER_EMAIL"] != DBNull.Value ? (dr["USER_EMAIL"].ToString()) : string.Empty;
            transaction.user.role= dr["USER_ROLE"] != DBNull.Value ? (dr["USER_ROLE"].ToString()) : string.Empty;
            transaction.user.discordId= dr["DISCORD_ID"] != DBNull.Value ? (dr["DISCORD_ID"].ToString()) : string.Empty;
            transaction.user.discordName= dr["DISCORD_NAME"] != DBNull.Value ? (dr["DISCORD_NAME"].ToString()) : string.Empty;
            transaction.user.discordMemberSince= dr["DISCORD_MEMBER_SINCE"] != DBNull.Value ? Convert.ToDateTime(dr["DISCORD_MEMBER_SINCE"].ToString()) : DateTime.MinValue;
            transaction.user.userName= dr["USER_NAME"] != DBNull.Value ? (dr["USER_NAME"].ToString()) : string.Empty;
            transaction.contestGuid= dr["CONTEST_GUID"] != DBNull.Value ? (dr["CONTEST_GUID"].ToString()) : string.Empty;
            transaction.transaction.Resultado= dr["RESULTADO"] != DBNull.Value ? Convert.ToBoolean(dr["RESULTADO"].ToString()) : false;
            transaction.transaction.MensajeResultado= dr["MENSAJE_RESULTADO"] != DBNull.Value ? (dr["MENSAJE_RESULTADO"].ToString()) : string.Empty;

            return transaction;
        }
        public WinnerPickerResponse MapWinnerPicker(SqlDataReader dr)
        {
            WinnerPickerResponse transaction = new WinnerPickerResponse();

            transaction.discordId= dr["DISCORD_ID"] != DBNull.Value ? (dr["DISCORD_ID"].ToString()) : string.Empty;
            transaction.discordName= dr["DISCORD_NAME"] != DBNull.Value ? (dr["DISCORD_NAME"].ToString()) : string.Empty;

            return transaction;
        }
    }
}

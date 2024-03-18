using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;
using Models.Response;
using Services.IServices;
using Services.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace devQuestBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {

        private readonly IContestService _contestServices;
        private readonly IConfiguration _configuration;
        public ContestController(IContestService contestServices, IConfiguration configuration)
        {
            _contestServices = contestServices ?? throw new ArgumentNullException(nameof(contestServices));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        [Route("createContest")]
        [ProducesResponseType(typeof(BaseResponseModel<ContestEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<ContestEntity>>> createContest([FromBody] CreateContestRequest contestRequest)
        {
            BaseResponseModel<ContestEntity> response = new BaseResponseModel<ContestEntity>();
            try
            {
                if (contestRequest== null)
                {
                    response.Objeto = new ContestEntity();
                    response.Codigo=(int)HttpStatusCode.BadRequest;
                    response.IsExito = false;
                }
                else
                {

                    ContestEntity contest = await _contestServices.CreateContest(contestRequest);
                    response.Objeto = contest;
                    response.Codigo=(int)HttpStatusCode.OK;
                    response.IsExito = true;
                }

            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("getContestById")]
        [ProducesResponseType(typeof(BaseResponseModel<ContestResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<ContestResponse>>> getContestById([FromBody] GetByIdRequest request)
        {
            BaseResponseModel<ContestEntity> response = new BaseResponseModel<ContestEntity>();
            try
            {
                if (request== null)
                {
                    response.Objeto = new ContestEntity();
                    response.Codigo=(int)HttpStatusCode.BadRequest;
                    response.IsExito = false;
                }
                else
                {

                    ContestEntity contest = await _contestServices.GetContestById(request);
                    response.Objeto = contest;
                    response.Codigo=(int)HttpStatusCode.OK;
                    response.IsExito = true;
                }

            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("SaveUserContest")]
        [ProducesResponseType(typeof(BaseResponseModel<TransactionModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<TransactionModel>>> saveUserContest([FromBody] SaveUserContestRequest request)
        {
            BaseResponseModel<SaveUserContestResponse> response = new BaseResponseModel<SaveUserContestResponse>();
            try
            {

                SaveUserContestResponse contest = await _contestServices.SaveUserContest(request);
                response.Objeto = contest;
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;


            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }

        //[HttpGet]
        //[Route("getContestByStatus")]
        //[ProducesResponseType(typeof(BaseResponseModel<List<ContestEntity>>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<BaseResponseModel<List<ContestEntity>>>> getContestByStatus(GetByStatusRequest request)
        //{
        //    BaseResponseModel<List<ContestEntity>> response = new BaseResponseModel<List<ContestEntity>>();
        //    try
        //    {
        //        if (request== null)
        //        {
        //            response.Objeto = new List<ContestEntity>();
        //            response.Codigo=(int)HttpStatusCode.BadRequest;
        //            response.IsExito = false;
        //        }
        //        else
        //        {

        //            List<ContestEntity> contest = await _contestServices.GetContestByStatus(request);
        //            response.Objeto = contest;
        //            response.Codigo=(int)HttpStatusCode.OK;
        //            response.IsExito = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Codigo=(int)HttpStatusCode.InternalServerError;
        //        response.IsExito=false;
        //        response.MensajeError=ex.Message;
        //    }

        //    return Ok(response);
        //}

        [HttpGet]
        [Route("getActiveContest")]
        [ProducesResponseType(typeof(BaseResponseModel<ContestEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<ContestEntity>>> getActiveContest()
        {
            BaseResponseModel<ContestEntity> response = new BaseResponseModel<ContestEntity>();
            try
            {
                ContestEntity contest = await _contestServices.GetActiveContest();
                response.Objeto = contest;
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;

            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("getContestUsers")]
        [ProducesResponseType(typeof(BaseResponseModel<List<UserEntity>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<List<UserEntity>>>> getContestUsers([Required] string contestGuid)
        {
            GetByIdRequest requestId = new GetByIdRequest();
            requestId.id=contestGuid;
            BaseResponseModel<List<UserEntity>> response = new BaseResponseModel<List<UserEntity>>();
            try
            {
                if (contestGuid== null)
                {
                    response.Objeto = new List<UserEntity>();
                    response.Codigo=(int)HttpStatusCode.BadRequest;
                    response.IsExito = false;
                }
                else
                {

                    List<UserEntity> contest = await _contestServices.GetContestUsers(requestId);
                    response.Objeto = contest;
                    response.Codigo=(int)HttpStatusCode.OK;
                    response.IsExito = true;
                }

            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("getContestHistory")]
        [ProducesResponseType(typeof(BaseResponseModel<List<ContestEntity>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<List<ContestEntity>>>> getCogetContestHistoryntestUsers()
        {
            BaseResponseModel<List<ContestEntity>> response = new BaseResponseModel<List<ContestEntity>>();
            try
            {

                List<ContestEntity> contest = await _contestServices.GetContestHistory();
                response.Objeto = contest;
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;


            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
            }

            return Ok(response);
        }


       


    }
}

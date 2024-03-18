using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;
using Services.IServices;
using System.Net;

namespace devQuestBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usuariosServices;
        private readonly IConfiguration _configuration;
        public UserController(IUserService usuariosServices, IConfiguration configuration)
        {
            _usuariosServices = usuariosServices ?? throw new ArgumentNullException(nameof(usuariosServices));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        [Route("getUsers")]
        [ProducesResponseType(typeof(BaseResponseModel<List<UserEntity>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<List<UserEntity>>>> getUsers()
        {
            BaseResponseModel<List<UserEntity>> response = new BaseResponseModel<List<UserEntity>>();
            try
            {
                response = await _usuariosServices.getUsers();
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;
                response.Objeto=response.Objeto;


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
        [Route("createUser")]
        [ProducesResponseType(typeof(BaseResponseModel<UserEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<UserEntity>>> createUser([FromBody] CreateUserRequest request)
        {
            BaseResponseModel<UserEntity> response = new BaseResponseModel<UserEntity>();
            try
            {
                UserEntity newUser = new UserEntity();
                newUser = await _usuariosServices.createUser(request);
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;
                response.Objeto=newUser;


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
        [Route("updateUser")]
        [ProducesResponseType(typeof(BaseResponseModel<TransactionModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<TransactionModel>>> updateUser(CreateUserRequest request)
        {
            BaseResponseModel<TransactionModel> response = new BaseResponseModel<TransactionModel>();
            try
            {
                TransactionModel transaction = new TransactionModel();
                transaction = await _usuariosServices.UpdateUser(request);
                response.Codigo=(int)HttpStatusCode.OK;
                response.IsExito = true;
                response.Objeto=transaction;


            }
            catch (Exception ex)
            {
                response.Codigo=(int)HttpStatusCode.InternalServerError;
                response.IsExito=false;
                response.MensajeError=ex.Message;
                response.Objeto=new TransactionModel();
            }

            return Ok(response);
        }

    }
}

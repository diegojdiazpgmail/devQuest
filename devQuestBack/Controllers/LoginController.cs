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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginServices;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService loginServices, IConfiguration configuration)
        {
            _loginServices = loginServices ?? throw new ArgumentNullException(nameof(loginServices));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(BaseResponseModel<UserEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BaseResponseModel<UserEntity>>> login(LoginRequest loginRequest)
        {
            BaseResponseModel<UserEntity> response = new BaseResponseModel<UserEntity>();
            try
            {
                if (loginRequest== null)
                {
                    response.Objeto = new UserEntity();
                    response.Codigo=(int)HttpStatusCode.BadRequest;
                    response.IsExito = false;
                }
                else
                {

                    UserEntity user = await _loginServices.login(loginRequest);
                    response.Objeto = user;
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
    }
}

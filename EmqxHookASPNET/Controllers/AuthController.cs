using EmqxHookASPNET.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmqxHookASPNET.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {       

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// https://www.emqx.io/docs/en/v5.0/security/authn/http.html
        /// Emqx HTTP 身份验证器将身份验证委托给自定义 HTTP API
        /// Body:
        /// {
        ///     "clientid": "${clientid}",
        ///     "username": "${username}",
        ///     "password": "${password}"
        /// }
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/auth")]
        public async Task<ActionResult<AuthenticateResponse>> HttpAuth([FromBody]ClientAuthenticateRequest request)
        {
            _logger.LogInformation("auth api");
            _logger.LogInformation($" { request.Clientid}  { request.Username }  { request.Password}");
            AuthenticateResponse authResp = new AuthenticateResponse 
            {
                Result = "allow",
                IsSuperuser = true
            };
            return  authResp;
        }

        /// <summary>
        /// https://www.emqx.io/docs/en/v5.0/security/authz/http.html
        /// Emqx 授权方将授权委托给给自定义 HTTP API
        /// {
        ///    "clientid": "${clientid}",
        ///    "username": "${username}",
        ///    "topic": "${topic}",
        ///    "action": "${action}",
        ///    "protoname": "${proto_name}"
        /// } 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/authz")]
        public async Task<ActionResult<AuthorizeResponse>> HttpAuthz([FromBody] ClientAuthorizeRequest request)
        {
            _logger.LogInformation("authz api");
            _logger.LogInformation($" {request.Clientid}  {request.Username}  {request.Topic} {request.Protoname}");
            AuthorizeResponse authzResp = new AuthorizeResponse
            { 
                Result = "allow"
            };
            return authzResp;
        }
    }
}
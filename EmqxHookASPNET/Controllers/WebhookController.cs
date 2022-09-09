using EmqxHookASPNET.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmqxHookASPNET.Controllers
{
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public WebhookController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/hook/{clientid}")]
        public async Task<ActionResult<HookResponse>> Hook(string clientid)
        {
            _logger.LogInformation($"hook api: {clientid}");
            StreamReader stream = new StreamReader(Request.Body);
            string body = await stream.ReadToEndAsync();
            _logger.LogInformation(body);

            HookResponse authResp = new HookResponse
            {
                Result = "ok",
                Message = "success"
            };
            return authResp;
        }
    }
}

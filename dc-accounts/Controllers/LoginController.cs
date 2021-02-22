using dc_accounts.Common;
using dc_accounts_services.Login;
using dc_accounts_viewmodels.Login;
using dc_common_view_model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace dc_accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : APIBaseController
    {
        private readonly ILogger<IndividualUserController> _logger;
        private readonly ILoginService _loginService;
        public LoginController(
              IHttpContextAccessor httpContextAccessor,
              IConfiguration configuration,
              ILogger<IndividualUserController> logger, ILoginService loginService) : base(httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            try
            {
                BaseObjectSetResponse<LoginResponse> response = await _loginService.LoginAsync(request); ;
                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }
    }
}

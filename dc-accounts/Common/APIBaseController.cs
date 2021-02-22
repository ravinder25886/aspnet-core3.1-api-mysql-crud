using dc_common_view_model;
using dc_exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace dc_accounts.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class APIBaseController : ControllerBase
    {
        public APIBaseController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ILogger logger)
        {
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
            Logger = logger;

            _identity = _httpContextAccessor?.HttpContext?.User?.Identity as ClaimsIdentity;
            _claims = _identity?.Claims;

            _currentUser.Id = Convert.ToInt64(_claims?.Where(x => x.Type == "UserId").FirstOrDefault()?.Value);
            //_currentUser.ClientId = Convert.ToInt32(_claims?.Where(x => x.Type == "ClientId").FirstOrDefault()?.Value);
           // _currentUser.UserName = _claims?.Where(x => x.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault()?.Value;
           // _currentUser.Email = _claims?.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault()?.Value;
        }

        #region Properties and Data Members

        protected readonly IHttpContextAccessor _httpContextAccessor;
        public readonly ClaimsIdentity _identity;
        public IEnumerable<Claim> _claims { get; }
        public LoggedInUser _currentUser = new LoggedInUser();
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        #endregion

        #region helper methods
        public IActionResult HandleResponse<T>(T response) where T : IErrorResponse
        {
            if (response.OriginalException != null)
            {
                var errorResult = response.OriginalException.GetErrorResponse(_currentUser);

                for (int i = 0; i < response.Errors.Count; i++)
                {
                    response.Errors[i] = response.Errors[i] + errorResult.ErrorID;
                }
            }

            if (response.Errors == null || (response.Errors?.Count == 0 && response.Errors?.Count == 0))
            {
                response.IsSuccess = true;

                return Ok(new
                {
                    response
                });
            }
            else
            {
                return BadRequest(new
                {
                    response
                });
            }
        }

        protected IActionResult ReturnBadRequest(Exception ex)
        {
            //throw ex;

            var response = ex.Message;// (_currentUser);

            return BadRequest(new
            {
                response
            });
        }
        #endregion
    }
}

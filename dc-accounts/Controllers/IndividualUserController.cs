using dc_accounts.Common;
using dc_accounts_services.User;
using dc_accounts_viewmodels.IndividualUser;
using dc_common_view_model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dc_accounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualUserController : APIBaseController
    {
        private readonly ILogger<IndividualUserController> _logger;
        private readonly IIndividualUserService _individualUser;
        public IndividualUserController(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration, 
            ILogger<IndividualUserController> logger, IIndividualUserService individualUser) : base(httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _individualUser = individualUser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                GetAllIndividualUsersResponse response = await _individualUser.GetAllAsync(); ;

                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                BaseObjectSetResponse<IndividualUserViewModel> response = await _individualUser.GetByIdAsync(id); ;

                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IndividualUserRequest request)
        {
            try
            {
                BaseObjectSetResponse<BaseResponse> response = await _individualUser.InsertAsync(request); ;
                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IndividualUserRequest request)
        {
            try
            {
                BaseObjectSetResponse<BaseResponse> response = await _individualUser.UpdateAsync(request); ;
                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }

        // DELETE api/<IndividualUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                BaseObjectSetResponse<BaseResponse> response = await _individualUser.DeleteAsync(id); ;
                return base.HandleResponse(response);
            }
            catch (Exception ex)
            {
                return base.ReturnBadRequest(ex);
            }
        }
    }
}

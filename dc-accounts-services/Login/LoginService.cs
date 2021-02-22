using dc_accounts_viewmodels.Login;
using dc_common_view_model;
using dc_data_context;
using dc_datamodels.account;
using dc_JWT_Security;
using dc_unitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace dc_accounts_services.Login
{
    public class LoginService : ILoginService
    {
        private UnitOfWork _unitOfWork;
        private IJWTokenService _jWTokenService;
        public LoginService(MySQLDBContext context, IJWTokenService jWTokenService)
        {
            _unitOfWork = new UnitOfWork(context);
            _jWTokenService = jWTokenService;
        }
        public async Task<BaseObjectSetResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var result = await _unitOfWork.UserRepository.FindAllBy(c => c.UserName.ToLower() == request.userName.ToLower());
            if (result.Count()==0)
            {
                return new BaseObjectSetResponse<LoginResponse> { Data = null, IsSuccess = false, Message = dc_messages.WRONG_USER, Errors = { dc_messages.WRONG_USER } };
            }
            UserDataModel user = result.FirstOrDefault();
            if (user.IsActive == false)
            {
                return new BaseObjectSetResponse<LoginResponse> { Data = null, IsSuccess = false, Message = dc_messages.ACCOUNT_DEACTIVATED, Errors = { dc_messages.ACCOUNT_DEACTIVATED } };
            }
            else if (user.IsDelete)
            {
                return new BaseObjectSetResponse<LoginResponse> { Data = null, IsSuccess = false, Message = dc_messages.ACCOUNT_DEACTIVATED, Errors = { dc_messages.ACCOUNT_DEACTIVATED } };
            }
            else
            {
                if (user.EncryptedPassword != request.password)
                {
                    return new BaseObjectSetResponse<LoginResponse> { Data = null, IsSuccess = false, Message = dc_messages.WRONG_USER, Errors = { dc_messages.WRONG_USER } };
                }
                else
                {
                    APIJWToken tokenData = _jWTokenService.CreateToken(user.Id.ToString(), user.UserName);
                    if (tokenData != null)
                    {
                        LoginResponse response = new LoginResponse
                        {
                            role = user.Role,
                            Token = tokenData.Token,
                            TokenExpiration = tokenData.TokenExpiration
                        };
                        return new BaseObjectSetResponse<LoginResponse> { Data = response, IsSuccess = true, Message = dc_messages.LOGIN_SUCCESSFULLY };
                    }
                    else
                    {
                        return new BaseObjectSetResponse<LoginResponse> { Data = null, IsSuccess = false, Message = dc_messages.ACCOUNT_DEACTIVATED, Errors = { dc_messages.ACCOUNT_DEACTIVATED } };
                    }
                }
            }

        }
    }
}

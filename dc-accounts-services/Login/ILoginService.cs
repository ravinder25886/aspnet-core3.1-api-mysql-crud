
using dc_accounts_viewmodels.Login;
using dc_common_view_model;
using dc_JWT_Security;
using System.Threading.Tasks;

namespace dc_accounts_services.Login
{
    public interface ILoginService
    {
        Task<BaseObjectSetResponse<LoginResponse>> LoginAsync(LoginRequest request);
    }
}

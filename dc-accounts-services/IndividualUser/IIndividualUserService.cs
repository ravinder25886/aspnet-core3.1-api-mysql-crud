using dc_accounts_viewmodels.IndividualUser;
using dc_common_view_model;
using System;
using System.Threading.Tasks;

namespace dc_accounts_services.User
{
    public interface IIndividualUserService:IDisposable
    {
        Task<BaseObjectSetResponse<BaseResponse>> InsertAsync(IndividualUserRequest request);
        Task<BaseObjectSetResponse<BaseResponse>> UpdateAsync(IndividualUserRequest request);
        Task<GetAllIndividualUsersResponse> GetAllAsync();
        Task<BaseObjectSetResponse<IndividualUserViewModel>> GetByIdAsync(long Id);
        Task<BaseObjectSetResponse<BaseResponse>> DeleteAsync(long Id);
        
    }
}

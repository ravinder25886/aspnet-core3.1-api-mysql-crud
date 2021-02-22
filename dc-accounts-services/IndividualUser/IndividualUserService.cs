using dc_accounts_viewmodels.IndividualUser;
using dc_common_view_model;
using dc_data_context;
using dc_datamodels.account;
using dc_datamodels.constants;
using dc_unitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dc_accounts_services.User
{
    public class IndividualUserService : IIndividualUserService
    {
        private UnitOfWork _unitOfWork;
        string serviceFor = "Individual user";
       // MySQLDBContext _context;
        public IndividualUserService(MySQLDBContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            //_context = context;

        }
        public void Dispose()
        {
            //Dispose objects 
        }
        public async Task<BaseObjectSetResponse<BaseResponse>> DeleteAsync(long Id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(Id);
            return new BaseObjectSetResponse<BaseResponse> { Data = new BaseResponse { Id = Id }, IsSuccess = true, Message = dc_messages.SubjectDeletedSuccess(serviceFor) };
        }


        public async Task<GetAllIndividualUsersResponse> GetAllAsync()
        {
            IList<UserDataModel> result=  await _unitOfWork.UserRepository.FindAllBy(c => c.Role == AccountRoleEnum.INDIVIDUAL_USER.ToString());
            GetAllIndividualUsersResponse response = new GetAllIndividualUsersResponse();
            List<IndividualUserViewModel> responseData = result?.Select(x => x.HandleIndividualUser()).ToList();
            response.Data = responseData;
            response.TotalRecords = result.Count;
            return response;
        }
        public async Task<BaseObjectSetResponse<IndividualUserViewModel>> GetByIdAsync(long Id)
        {
            UserDataModel userDataModel = await _unitOfWork.UserRepository.GetByIdAsync(Id);
            if (userDataModel != null)
            {
                IndividualUserViewModel responseData = userDataModel.HandleIndividualUser();
                return new BaseObjectSetResponse<IndividualUserViewModel> { Data = responseData, IsSuccess = true };
            }
            else
            {
                return new BaseObjectSetResponse<IndividualUserViewModel> { Data = null, IsSuccess = false,Message=dc_messages.SubjectNotFound(serviceFor),Errors = { dc_messages.SubjectNotFound(serviceFor) } };
            }
            
        }

        public async Task<BaseObjectSetResponse<BaseResponse>> InsertAsync(IndividualUserRequest request)
        {
            UserDataModel dataModel = request.Handle();
            dataModel.Id = 0;
            // TODO: Check If User name is already exsit
            dataModel = await _unitOfWork.UserRepository.InsertAsync(dataModel);
            return new BaseObjectSetResponse<BaseResponse> { Data =new BaseResponse { Id=dataModel.Id}, IsSuccess = true,Message= dc_messages.SubjectCreatedSuccess(serviceFor) };
        }
        public async Task<BaseObjectSetResponse<BaseResponse>> UpdateAsync(IndividualUserRequest request)
        {
            UserDataModel dataModel = request.Handle();
            // TODO: Check If User name is already exsit
            dataModel = await _unitOfWork.UserRepository.UpdateAsync(dataModel);
            return new BaseObjectSetResponse<BaseResponse> { Data = new BaseResponse { Id = dataModel.Id }, IsSuccess = true, Message = dc_messages.SubjectUpdatedSuccess(serviceFor) };
        }
        
    }
}

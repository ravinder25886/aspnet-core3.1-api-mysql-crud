using dc_datamodels.account;
using dc_datamodels.constants;
using System;

namespace dc_accounts_viewmodels.IndividualUser
{
    public static class UserExtensions
    {
        public static IndividualUserViewModel HandleIndividualUser(this UserDataModel request)
        {
            IndividualUserViewModel responseData = new IndividualUserViewModel
            {
                id = request.Id,
                fullName = request.FullName,
                userName = request.UserName
            };
            return responseData;
        }
        public static UserDataModel Handle(this IndividualUserRequest request)
        {
            UserDataModel response = new UserDataModel
            {
                UserName = request.userName,
                AccountType = AccountRoleEnum.INDIVIDUAL_USER.ToString(),
                FullName = request.fullName,
                Role = AccountRoleEnum.INDIVIDUAL_USER.ToString()
            };
            if (request.id == 0)//Insert request
            {
                response.EncryptedPassword = request.password;
                response.CreationDateTime = DateTime.UtcNow;
            }
            else//Update request
            {
                response.Id = request.id;
                response.LastUpdateDateTime = DateTime.UtcNow;
            }
            return response;
        }
    }
}

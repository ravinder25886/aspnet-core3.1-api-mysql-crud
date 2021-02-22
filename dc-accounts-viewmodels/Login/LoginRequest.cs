using dc_JWT_Security;
using System.ComponentModel.DataAnnotations;

namespace dc_accounts_viewmodels.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User name is required ")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password is required ")]
        public string password { get; set; }
    }
    public class LoginResponse: APIJWToken
    {
        public string role { get; set; }
    }
}

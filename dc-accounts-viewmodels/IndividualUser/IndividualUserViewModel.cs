using System.ComponentModel.DataAnnotations;

namespace dc_accounts_viewmodels.IndividualUser
{
    public class IndividualUserViewModel
    {
        public long id { get; set; }
        [Required(ErrorMessage = "Full name is required ")]
        [StringLength(100, ErrorMessage = "Full name can't be longer than 60 characters")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "User name is required ")]
        public string userName { get; set; }
        public string role { get; set; }
    }
    public class IndividualUserRequest : IndividualUserViewModel
    {
        [Required(ErrorMessage = "Password is required ")]
        public string password { get; set; }
    }
}

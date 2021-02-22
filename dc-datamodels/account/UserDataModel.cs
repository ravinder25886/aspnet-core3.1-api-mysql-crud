using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dc_datamodels.account
{
    [Table("Users")]
    public class UserDataModel:BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string AccountType { get; set; }
        [Required]
        [MaxLength(300)]
        public string EncryptedPassword { get; set; }
        public string Role { get; set; }
    }
}

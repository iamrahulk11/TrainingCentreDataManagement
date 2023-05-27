using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingCentreDataManagement.Models
{
    public class LoginModel
    {
        [Key]
        public int AutoID { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string? username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string? password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
    public interface ILogin
    {
        bool credentialCheck(LoginModel u);
    }
}

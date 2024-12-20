using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace AppHarbuz1.Models.Account
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel {  get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is mandatory")]
        public string Login { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is mandatory")]
        public string Login { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]

        public string RepeatPassword { get; set; }
    }
}

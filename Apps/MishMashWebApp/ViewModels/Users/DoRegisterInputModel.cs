using System.ComponentModel.DataAnnotations;

namespace MishMashWebApp.ViewModels.Users
{
    public class DoRegisterInputModel
    {
        [StringLength(maximumLength:20,MinimumLength =3)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength:20,MinimumLength =6)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ps.dmv.web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Uporabniško ime")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutno geslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora biti dolgo vsaj {2} znakov.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Novo geslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovi geslo")]
        [Compare("NewPassword", ErrorMessage = "Novo geslo in ponovitev gesla se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Uporabniško ime")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Geslo")]
        public string Password { get; set; }

        [Display(Name = "Zapomni si me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Uporabniško ime")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora biti dolgo vsaj {2} znakov.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Geslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovi geslo")]
        [Compare("Password", ErrorMessage = "Novo geslo in ponovitev gesla se ne ujemata.")]
        public string ConfirmPassword { get; set; }
    }
}

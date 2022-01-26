using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RegisterViewModel
    {
        [Required] public string ReturnUrl { get; set; }
        [Required]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
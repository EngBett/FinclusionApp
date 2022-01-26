using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class LoginViewModel
    {
        [Required]
        public string ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}   
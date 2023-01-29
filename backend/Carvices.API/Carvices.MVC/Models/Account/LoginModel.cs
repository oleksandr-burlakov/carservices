using System.ComponentModel.DataAnnotations;

namespace Carvices.MVC.Models.Account
{
    public class LoginModel
    {
        [Required]
        [MaxLength(255)]
        public required string Login { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Accounts
{
    public record LoginRequest
    {
        [Required]
        public required string Login { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}

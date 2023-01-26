using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Accounts
{
    public record RegisterRequest
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}

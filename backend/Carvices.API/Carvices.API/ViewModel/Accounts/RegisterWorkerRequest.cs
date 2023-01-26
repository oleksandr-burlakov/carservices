using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Accounts
{
    public class RegisterWorkerRequest
    {
        [Required]
        [MaxLength(255)]
        public required string UserName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
    }
}

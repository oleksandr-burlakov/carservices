using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Accounts
{
    public class RegisterWorkerRequest
    {
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
    }
}

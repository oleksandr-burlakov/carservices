using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Services
{
    public class RegisterServiceRequest
    {
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.ServiceActions
{
    public class CreateServiceActionRequest
    {
        [Required]
        public Guid ServiceId { get; set; }
        public decimal? Price { get; set; }
        public decimal? HourEstimation { get; set; }
        public bool IsFree { get; set; } = true;
        [MaxLength(255)]
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}

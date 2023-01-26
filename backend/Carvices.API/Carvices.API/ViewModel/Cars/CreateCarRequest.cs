using Carvices.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Carvices.API.ViewModel.Cars
{
    public record CreateCarRequest
    {
        [MaxLength(255)]
        public required string Name { get; set; }
        public Guid OwnerId { get; set; }
        public required CarStatus CarStatus { get; set; }
    }
}

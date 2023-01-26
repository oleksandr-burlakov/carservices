using Carvices.DAL.Entities;

namespace Carvices.BLL.DTO.Cars
{
    public class CreateCarDTO
    {
        public required string Name { get; set; }
        public Guid OwnerId { get; set; }
        public CarStatus CarStatus { get; set; }
    }
}

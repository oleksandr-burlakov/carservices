using Carvices.DAL.Entities;

namespace Carvices.BLL.DTO.Cars
{
    public class CreateCarDTO
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public CarStatus CarStatus { get; set; }
    }
}

using Carvices.DAL.Entities;

namespace Carvices.BLL.DTO.Cars
{
    public class GetMyCarsDTO
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required CarStatus CarStatus { get; set; }
    }
}

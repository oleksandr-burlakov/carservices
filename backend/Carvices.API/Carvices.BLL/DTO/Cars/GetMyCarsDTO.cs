using Carvices.DAL.Entities;

namespace Carvices.BLL.DTO.Cars
{
    public class GetMyCarsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CarStatus CarStatus { get; set; }
    }
}

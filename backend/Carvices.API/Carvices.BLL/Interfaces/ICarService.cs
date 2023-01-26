using Carvices.BLL.DTO.Cars;

namespace Carvices.BLL.Interfaces
{
    public interface ICarService
    {
        public Task<Guid> CreateAsync(CreateCarDTO createCar);
        public Task<ICollection<GetMyCarsDTO>> GetMyCarsAsync(Guid userId);
    }
}

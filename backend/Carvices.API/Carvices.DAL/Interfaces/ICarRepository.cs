using Carvices.DAL.Entities;

namespace Carvices.DAL.Interfaces
{
    public interface ICarRepository
    {
        public Task<Guid> CreateAsync(Car car);
        public Task<ICollection<Car>> GetByOwnerIdAsync(Guid ownerId);
    }
}

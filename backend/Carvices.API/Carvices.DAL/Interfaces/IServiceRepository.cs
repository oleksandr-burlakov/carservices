using Carvices.DAL.Entities;

namespace Carvices.DAL.Interfaces
{
    public interface IServiceRepository
    {
        public Task<Guid> AddAsync(Service service);
    }
}

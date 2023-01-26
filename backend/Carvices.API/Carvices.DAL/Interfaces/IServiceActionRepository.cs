using Carvices.DAL.Entities;

namespace Carvices.DAL.Interfaces
{
    public interface IServiceActionRepository
    {
        public Task<Guid> AddAsync(ServiceAction serviceAction);
    }
}

using Carvices.DAL.Entities;
using Carvices.DAL.Interfaces;

namespace Carvices.DAL.Realization
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly EFContext _context;
        public ServiceRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddAsync(Service service)
        {
            var returnService = (await _context.Services.AddAsync(service));
            await _context.SaveChangesAsync();
            return returnService.Entity.Id;
        }
    }
}

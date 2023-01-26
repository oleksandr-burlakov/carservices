using Carvices.BLL.DTO.ServiceActions;

namespace Carvices.BLL.Interfaces
{
    public interface IServiceActionService
    {
        public Task<Guid> AddAsync(AddServiceActionDTO dto);
    }
}

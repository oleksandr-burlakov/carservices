using Carvices.BLL.DTO.Services;

namespace Carvices.BLL.Interfaces
{
    public interface IServiceService
    {
        public Task<Guid> RegisterAsync(RegisterServiceDTO dto);
    }
}

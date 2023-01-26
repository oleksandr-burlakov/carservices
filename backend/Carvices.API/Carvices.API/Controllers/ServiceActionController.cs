using Carvices.API.ViewModel.ServiceActions;
using Carvices.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carvices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ServiceActionController : ControllerBase
    {
        private readonly IServiceActionService _serviceActionService;
        public ServiceActionController(IServiceActionService serviceActionService)
        {
            _serviceActionService = serviceActionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateServiceActionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _serviceActionService.AddAsync(new BLL.DTO.ServiceActions.AddServiceActionDTO()
            {
                Name = request.Name,
                Description = request.Description,
                HourEstimation = request.HourEstimation,
                IsFree = request.IsFree,
                Price = request.Price,
                ServiceId = request.ServiceId,
            });
            return Ok(result);
        }

        [HttpGet("get-by-service/{serviceId}")]
        public async Task<IActionResult> GetByService([FromQuery] Guid serviceId)
        {
            var result = await _serviceActionService.GetByServiceAsync(serviceId);
            return Ok(result);
        }
    }
}

using Carvices.API.ViewModel.Services;
using Carvices.BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Carvices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNew(RegisterServiceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _serviceService.RegisterAsync(new BLL.DTO.Services.RegisterServiceDTO()
            {
                Latitude = request.Latitude,
                Longtitude = request.Longtitude,
                Name = request.Name
            });
            return Ok(id);
        }
    }
}

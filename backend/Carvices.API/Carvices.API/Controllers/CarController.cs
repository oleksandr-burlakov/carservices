using Carvices.API.Configuration;
using Carvices.API.ViewModel.Cars;
using Carvices.BLL.DTO.Cars;
using Carvices.BLL.Interfaces;
using Carvices.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carvices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly UserManager<User> _userManager;
        public CarController(ICarService carService, UserManager<User> userManager)
        {
            _carService = carService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("create-car")]
        public async Task<IActionResult> CreateCar(CreateCarRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToString());
            }
            var user = await User.GetUser(_userManager);

            var createdCarId = await _carService.CreateAsync(new CreateCarDTO()
            {
                CarStatus = request.CarStatus,
                Name = request.Name,
                OwnerId = user!.Id
            });
            return Ok(createdCarId);
        }

        [HttpGet("get-my-cars")]
        public async Task<IActionResult> GetMyCars()
        {
            var ownerId = User.GetUserId();
            var cars = await _carService.GetMyCarsAsync(ownerId);
            return Ok(cars);
        }
    }
}

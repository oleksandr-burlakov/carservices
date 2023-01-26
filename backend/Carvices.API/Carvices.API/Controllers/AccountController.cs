using Carvices.API.ViewModel.Accounts;
using Carvices.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Claims;

namespace Carvices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToString());
            }

            var existedUser = (await _userManager.FindByEmailAsync(request.Email)) ?? (await _userManager.FindByNameAsync(request.UserName));
            if (existedUser is not null)
            {
                return BadRequest($"User with email '{request.Email}' or username '{request.UserName}' is already registered");
            }

            await _userManager.CreateAsync(new DAL.Entities.User()
            {
                UserName = request.UserName,
                Email = request.Email
            }, request.Password);

            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToString());
            }

            var existedUser = (await _userManager.FindByEmailAsync(request.Login)) ?? (await _userManager.FindByNameAsync(request.Login));
            if (existedUser is null)
            {
                return BadRequest($"User with email '{request.Login}' or username '{request.Login}' doesn't exist");
            }

            var isRightPassword = await _userManager.CheckPasswordAsync(existedUser, request.Password);

            if (!isRightPassword)
            {
                return BadRequest("Password is not correct");
            }

            var claims = new List<Claim>
            {
                new Claim(type: ClaimTypes.NameIdentifier, value: existedUser.Id.ToString()),
                new Claim(type: ClaimTypes.Email, value: existedUser.Email!),
                new Claim(type: ClaimTypes.Name, value: existedUser.UserName!)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _userManager.CreateAsync(new DAL.Entities.User()
            {
                UserName = existedUser.UserName,
                Email = existedUser.Email
            }, request.Password);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                });

            return Ok();
        }



        [HttpPost("register-worker")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> RegisterWorker(RegisterWorkerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToString());
            }

            var existedUser = (await _userManager.FindByEmailAsync(request.Email)) ?? (await _userManager.FindByNameAsync(request.UserName));
            if (existedUser is not null)
            {
                return BadRequest($"User with email '{request.Email}' or username '{request.UserName}' is already registered");
            }

            await _userManager.CreateAsync(new DAL.Entities.User()
            {
                UserName = request.UserName,
                Email = request.Email,
                JobId = request.ServiceId,
            }, request.Password);

            return Ok();
        }
    }
}

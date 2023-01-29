using Carvices.MVC.Configurations;
using Carvices.MVC.Models.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;

namespace Carvices.MVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        public AccountController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient(Constants.HttpClientName);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
               "api/Account/login", model);

            if (!response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result); // TODO: add logger
                model.ErrorMessage = result;
                return View(model);
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;
using System.Net;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly RegisterService _registerService;

        public RegisterController(ILogger<RegisterController> logger, RegisterService registerService)
        {

            _logger = logger;
            _registerService = registerService;
        }

        [HttpPost(Name = "Register")]
        public async Task<Account> Register(string userName, string password, string role)
        {
            var result = await _registerService.Register(userName, password, role);

            var account = new Account();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                account = result.Data ?? throw new InvalidOperationException();
            }

            return account;
        }
    }
}

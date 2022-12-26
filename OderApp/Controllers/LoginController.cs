using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;
using System.Net;
using InvalidOperationException = System.InvalidOperationException;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly LoginService _loginService;

        public LoginController(ILogger<LoginController> logger, LoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpGet(Name = "Login")]
        public async Task<Account> Login(string userName, string passWord)
        {
            var result = await _loginService.Login(userName, passWord);

            Account account = new Account();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                account = result.Data ?? throw new InvalidOperationException();
            }

            return account;
        }
    }
}
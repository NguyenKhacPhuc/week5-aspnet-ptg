using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;
using System.Net;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<OrderController> _logger;
        private readonly LoginService _loginService;

        public OrderController(ILogger<OrderController> logger, LoginService loginService)
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
                account = result.Data;
            }

            return account;
        }
    }
}
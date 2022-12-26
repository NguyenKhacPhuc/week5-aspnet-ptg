using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;
using System.Net;
using OderApp.DataSource;
using OderApp.DataSource.Entities;
using OderApp.Helper;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly RegisterService _registerService;
        private readonly OrderDbContext _orderDbContext;

        public RegisterController(ILogger<RegisterController> logger, RegisterService registerService, OrderDbContext orderDbContext)
        {
            _logger = logger;
            _registerService = registerService;
            _orderDbContext = orderDbContext;
        }

        [HttpPost(Name = "Register")]
        public async Task<User> Register(string name, string email, string password, int role)
        {
            var result = await _registerService.Register(name, email, password, role);

            var user = new User();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                user = result.Data ?? throw new InvalidOperationException();
            }

            return user;
        }
    }
}

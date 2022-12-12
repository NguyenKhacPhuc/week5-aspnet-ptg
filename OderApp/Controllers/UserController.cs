using System;
using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;

namespace OderApp.Controllers
{
	[ApiController]
    [Route("[controller]")]
	public class UserController: ControllerBase
	{
        private readonly ILogger<ItemController> _logger;

        private readonly UserService _userService;

        public UserController(ILogger<ItemController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost(Name = "UpdateUser")]
        public async Task<User?> UpdateItem(User user)
        {
           return await _userService.UpdateUser(user);
        }
    }
}


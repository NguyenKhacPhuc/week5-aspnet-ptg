using Microsoft.AspNetCore.Mvc;
using OderApp.DataSource.Entities;
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
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("getAllMenu")]
        public async Task<List<MenuItem>> GetMenu()
        {
            return await _customerService.GetMenu();
        }

        [HttpGet("getMenuByCategory/{category}", Name = "getMenuByCategory")]
        public async Task<List<MenuItem>> GetMenuByCategory(string category)
        {
            return await _customerService.GetMenuByCategory(category);
        }

        [HttpGet("getOrderdItems/{accountId}", Name = "getOrderedItems")]
        public async Task<List<MenuItem>> GetOrderedItemsByAccountId(int accountId)
        {
            return await _customerService.GetOrderedItemsByAccountId(accountId);
        }

        [HttpGet("getTotalCartPrice/{accountId}", Name = "getTotalCartPrice")]
        public async Task<double> GetTotalCartPriceByAccountId(int accountId)
        {
            return await _customerService.GetTotalCartPriceByAccountId(accountId);
        }

        [HttpPost("orderItems", Name = "orderItems")]
        public async Task<List<MenuItem>> OrderItems(List<KeyValuePair<int, int>> orderItems, int accountId)
        {
            return await _customerService.OrderItems(orderItems, accountId);
        }
    }
}
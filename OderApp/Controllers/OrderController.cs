using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("getAllMenu")]
        public async Task<List<Item>> GetMenu()
        {
            return await _customerService.GetMenu();
        }

        [HttpGet("getMenuByCategory/{category}", Name = "getMenuByCategory")]
        public async Task<List<Item>> GetMenuByCategory(string category)
        {
            return await _customerService.GetMenuByCategory(category);
        }

        [HttpGet("getOrderdItems/{accountId}", Name = "getOrderedItems")]
        public async Task<List<Item>> GetOrderedItemsByAccountId(int accountId)
        {
            return await _customerService.GetOrderedItemsByAccountId(accountId);
        }

        [HttpGet("getTotalCartPrice/{accountId}", Name = "getTotalCartPrice")]
        public async Task<double> GetTotalCartPriceByAccountId(int accountId)
        {
            return await _customerService.GetTotalCartPriceByAccountId(accountId);
        }

        [HttpPost("orderItems", Name = "orderItems")]
        public async Task<List<Item>> OrderItems(List<KeyValuePair<string, int>> orderItems, int accountId)
        {
            return await _customerService.OrderItems(orderItems, accountId);
        }
    }
}
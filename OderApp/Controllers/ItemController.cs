using Microsoft.AspNetCore.Mvc;
using OderApp.Services;
using OderApp.Models;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;

        private readonly ItemService _itemService;

        public ItemController(ILogger<ItemController> logger, ItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpPut(Name = "AddItem")]
        public async Task<IActionResult> AddItem(Item item)
        {
            await _itemService.AddItem(item);
            return new OkObjectResult(item);
        }

        [HttpPost(Name = "UpdateItem")]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            await _itemService.UpdateItem(item);
            return new OkObjectResult(item);
        }

        [HttpGet(Name = "GetAllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            var result = await _itemService.GetAllItem();
            return new OkObjectResult(result);
        }

        [HttpDelete(Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(string itemId)
        {
            await _itemService.DeleteItem(itemId);
            return new OkObjectResult(itemId);
        }
    }
}


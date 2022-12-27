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
        public async Task<Item?> AddItem(Item item)
        {
            return await _itemService.AddItem(item);
        }

        [HttpPost(Name = "UpdateItem")]
        public async Task<Item?> UpdateItem(Item item)
        {
            return await _itemService.UpdateItem(item);
        }

        [HttpGet(Name = "GetAllItem")]
        public async Task<List<Item>> GetAllItem()
        {
            return await _itemService.GetAllItem();
        }

        [HttpDelete(Name = "DeleteItem")]
        public async Task<Item?> DeleteItem(string itemId, bool isClearAll)
        {
            return await _itemService.DeleteItem(itemId, isClearAll);
        }
    }
}


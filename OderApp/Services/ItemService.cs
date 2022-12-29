using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;
using System.Net;

namespace OderApp.Services
{
    public interface ItemService
    {
        public Task<Result<List<Item>>> GetAllItem();

        public Task<Result<Item>> AddItem(Item item);

        public Task<Result<Item>> UpdateItem(Item item);

        public Task<Result<string>> DeleteItem(string itemId);
    }

    public class ItemServiceImpl : ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemServiceImpl(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Result<Item>> AddItem(Item item)
        {
            await _itemRepository.AddItem(item.ConvertToItemEntity());
            return new Result<Item>(HttpStatusCode.OK, item, null);
        }

        public async Task<Result<string>> DeleteItem(string itemId)
        {
            await _itemRepository.DeleteItem(itemId);
            return new Result<string>(HttpStatusCode.OK, itemId, null);
        }

        public async Task<Result<List<Item>>> GetAllItem()
        {
            var listItem = (await _itemRepository.GetAllItem()).ConvertAll(item => item.ConvertToItemModel());
            return new Result<List<Item>>(HttpStatusCode.OK, listItem, null); ;
        }

        public async Task<Result<Item>> UpdateItem(Item item)
        {
            await _itemRepository.UpdateItem(item.ConvertToItemEntity());
            return new Result<Item>(HttpStatusCode.OK, item, null);
        }
    }
}


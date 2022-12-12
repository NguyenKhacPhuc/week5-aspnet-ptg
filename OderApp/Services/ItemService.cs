using System;
using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;
using OderApp.Services;

namespace OderApp.Services
{
    public interface ItemService
    {
        public Task<List<Item>> GetAllItem();

        public Task<Item?> AddItem(Item item);

        public Task<Item?> UpdateItem(Item item);

        public Task<Item?> DeleteItem(string itemId);
    }

    public class ItemServiceImpl : ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemServiceImpl(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item?> AddItem(Item item)
        {
            return (await _itemRepository.AddItem(item.ConvertToItemEntity())).ConvertToItem();
        }

        public async Task<Item?> DeleteItem(string itemId)
        {
            return (await _itemRepository.DeleteItem(itemId)).ConvertToItem();
        }

        public async Task<List<Item>> GetAllItem()
        {
            var listItem = (await _itemRepository.GetAllItem()).ConvertAll(item => item.ConvertToItem());
            listItem.RemoveAll(item => item == null);
            return listItem;
        }

        public async Task<Item?> UpdateItem(Item item)
        {
            return (await _itemRepository.UpdateItem(item.ConvertToItemEntity())).ConvertToItem();
        }
    }
}


using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IItemRepository
    {
        public Task<List<ItemEntity>> GetAllItem();

        public Task<ItemEntity?> UpdateItem(ItemEntity item);

        public Task<ItemEntity?> DeleteItem(string itemId, bool isClearAll);

        public Task<ItemEntity?> AddItem(ItemEntity item);
    }

    public class ItemRepositoryImpl : IItemRepository
    {
        private readonly ItemDao _itemDao;

        public ItemRepositoryImpl(ItemDao itemDao)
        {
            _itemDao = itemDao;
        }

        public async Task<ItemEntity?> AddItem(ItemEntity item)
        {
            return await _itemDao.Insert(item);
        }

        public async Task<ItemEntity?> DeleteItem(string itemId, bool isClearAll)
        {
            return await _itemDao.Delete(itemId, isClearAll);
        }

        public async Task<List<ItemEntity>> GetAllItem()
        {
            return await _itemDao.GetAll();
        }

        public async Task<ItemEntity?> UpdateItem(ItemEntity item)
        {
            return await _itemDao.Update(item);
        }
    }
}


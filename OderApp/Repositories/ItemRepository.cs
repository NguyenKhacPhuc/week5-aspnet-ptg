using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IItemRepository
    {
        public Task<List<ItemEntity>> GetAllItem();

        public Task UpdateItem(ItemEntity item);

        public Task DeleteItem(string itemId);

        public Task AddItem(ItemEntity item);
    }

    public class ItemRepositoryImpl : IItemRepository
    {
        private readonly ItemDao _itemDao;

        public ItemRepositoryImpl(ItemDao itemDao)
        {
            _itemDao = itemDao;
        }

        public async Task AddItem(ItemEntity item)
        {
            await _itemDao.Insert(item);
        }

        public async Task DeleteItem(string itemId)
        {
            await _itemDao.Delete(itemId);
        }

        public async Task<List<ItemEntity>> GetAllItem()
        {
            return await _itemDao.GetAll();
        }

        public async Task UpdateItem(ItemEntity item)
        {
            await _itemDao.Update(item);
        }
    }
}


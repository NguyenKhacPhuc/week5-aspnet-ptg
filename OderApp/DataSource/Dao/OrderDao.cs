using OderApp.DataSource.Entities;
using OderApp.Helper;

namespace OderApp.DataSource.Dao
{
    public interface IOrderDao
    {
        public Task<List<ItemEntity>> GetOrderedItemsByAccountId(int accountId);
        public Task<List<ItemEntity>> OrderItems(List<OrderItem> orderItems, int accountId);
    }

    public class OrderDaoImpl : IOrderDao
    {

        private readonly FileJsonHandler _fileJsonHandler;
        private readonly MenuDao _menuDao;
        public OrderDaoImpl(FileJsonHandler fileJsonHandler, MenuDao menuDao)
        {
            _fileJsonHandler = fileJsonHandler;
            _menuDao = menuDao;
        }
        public async Task<List<ItemEntity>> GetOrderedItemsByAccountId(int accountId)
        {
            var orderStorage = await GetAllOrderEntity();
            var orderItems = orderStorage.Find(oderEntity => oderEntity.AccountId == accountId)?.OrderItems;
            if (orderItems == null || orderItems.Count == 0) return new List<ItemEntity>();
            var menu = await _menuDao.GetAll();
            return menu.FindAll(menuEntity => orderItems
                .Select(obj => obj.ItemId)
                .ToList().
                Contains(menuEntity.Id));
        }

        public async Task<List<ItemEntity>> OrderItems(List<OrderItem> orderItems, int accountId)
        {
            var orderStorage = await GetAllOrderEntity();
            var orderEntity = orderStorage.Find(orderEntity => orderEntity.AccountId == accountId);
            if (orderEntity == null)
            {
                orderStorage.Add(new OrderEntity(accountId, orderItems));
                await _fileJsonHandler.writeFile(Constant.CART_STORE_PATH_FILE, orderStorage);
            }
            else
            {
                var index = orderStorage.FindIndex(obj => obj.AccountId == accountId);
                orderStorage[index] = new OrderEntity(accountId, orderItems);
                await _fileJsonHandler.writeFile(Constant.CART_STORE_PATH_FILE, orderStorage);
            }
            return await GetOrderedItemsByAccountId(accountId);
        }

        private async Task<List<OrderEntity>> GetAllOrderEntity()
        {
            return await _fileJsonHandler.readFile<List<OrderEntity>>(Constant.CART_STORE_PATH_FILE);
        }
    }
}

using OderApp.DataSource.Entities;
using OderApp.Helper;

namespace OderApp.DataSource.Dao
{
    public interface IOrderDao
    {
        public Task<List<ItemEntity>> GetOrderedItemsByAccountId(int accountId);
        public Task<List<ItemEntity>> OrderItems(List<OrderItem> orderItems, int acccountId);
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
            var orderItems = orderStorage.Find(oderEntity => oderEntity.AccountId == accountId).OrderItems;
            if (orderItems.Count != 0)
            {
                var menu = await _menuDao.GetAll();
                return menu.FindAll(menuEntity => orderItems
                            .Select(obj => obj.ItemId)
                            .ToList().
                            Contains(menuEntity.Id));
            }
            return new List<ItemEntity>();
        }

        public async Task<List<ItemEntity>> OrderItems(List<OrderItem> orderItems, int acccountId)
        {
            var orderStorage = await GetAllOrderEntity();
            var orderEntity = orderStorage.Find(orderEntity => orderEntity.AccountId == acccountId);
            if (orderEntity == null)
            {
                orderStorage.Add(new OrderEntiy(acccountId, orderItems));
                await _fileJsonHandler.writeFile(Constant.CART_STORE_PATH_FILE, orderStorage);
            }
            else
            {
                var index = orderStorage.FindIndex(obj => obj.AccountId == acccountId);
                orderStorage[index] = new OrderEntiy(acccountId, orderItems);
                await _fileJsonHandler.writeFile(Constant.CART_STORE_PATH_FILE, orderStorage);
            }
            return await GetOrderedItemsByAccountId(acccountId);
        }

        private async Task<List<OrderEntiy>> GetAllOrderEntity()
        {
            return await _fileJsonHandler.readFile<List<OrderEntiy>>(Constant.CART_STORE_PATH_FILE);
        }
    }
}

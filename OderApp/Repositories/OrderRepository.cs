using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<MenuItemEntity>> GetOrderedItemsByAccountId(int accountId);
        public Task<List<MenuItemEntity>> OrderItems(List<OrderItem> orderItems, int accountId);
    }

    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly IOrderDao _orderDao;
        public OrderRepositoryImpl(IOrderDao orderDao)
        {
            _orderDao = orderDao;
        }
        public async Task<List<MenuItemEntity>> GetOrderedItemsByAccountId(int accountId)
        {
            return await _orderDao.GetOrderedItemsByAccountId(accountId);
        }

        public async Task<List<MenuItemEntity>> OrderItems(List<OrderItem> orderItems, int accountId)
        {
            return await _orderDao.OrderItems(orderItems, accountId);
        }
    }
}

using OderApp.DataSource.Entities;
using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;

namespace OderApp.Services
{

    public interface ICustomerService
    {
        public Task<List<MenuItem>> GetMenu();
        public Task<List<MenuItem>> GetMenuByCategory(string category);
        public Task<List<MenuItem>> GetOrderedItemsByAccountId(int accountId);
        public Task<double> GetTotalCartPriceByAccountId(int accountId);
        public Task<List<MenuItem>> OrderItems(List<KeyValuePair<int, int>> orderItems, int accountId);
    }

    public class CustomerServiceImpl : ICustomerService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderRepository _orderRepository;
        public CustomerServiceImpl(IMenuRepository menuRepository, IOrderRepository orderRepository)
        {
            _menuRepository = menuRepository;
            _orderRepository = orderRepository;
        }
        public async Task<List<MenuItem>> GetMenu()
        {
            var result = new List<MenuItem>();
            var menuEntities = await _menuRepository.GetAll();
            foreach (var menuEntity in menuEntities)
            {

                result.Add(menuEntity.ConvertToMenuItem());
            }

            return result;
        }

        public async Task<List<MenuItem>> GetMenuByCategory(string category)
        {
            var result = new List<MenuItem>();
            var categoryId = (int)Enum.Parse(typeof(Category), category.ToLower());
            var menuEntities = await _menuRepository.GetMenuByCategory(categoryId);
            foreach (var menuEntity in menuEntities)
            {
                result.Add(menuEntity.ConvertToMenuItem());
            }

            return result;
        }

        public async Task<List<MenuItem>> GetOrderedItemsByAccountId(int accountId)
        {
            var result = new List<MenuItem>();
            var orderedItems = await _orderRepository.GetOrderedItemsByAccountId(accountId);
            foreach (var item in orderedItems)
            {
                result.Add(item.ConvertToMenuItem());
            }
            return result;

        }

        public async Task<double> GetTotalCartPriceByAccountId(int accountId)
        {
            double totalPrice = 0.0;
            var orderedItems = await GetOrderedItemsByAccountId(accountId);
            foreach (var item in orderedItems)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }

        public async Task<List<MenuItem>> OrderItems(List<KeyValuePair<int, int>> orderItems, int accountId)
        {
            var orderItemList = new List<OrderItem>();
            orderItems.ForEach(item => orderItemList.Add(new OrderItem(item.Key, item.Value)));
            var result = new List<MenuItem>();
            var orderMenuItemEntities = await _orderRepository.OrderItems(orderItemList, accountId);
            foreach (var menuItemEntity in orderMenuItemEntities)
            {
                result.Add(menuItemEntity.ConvertToMenuItem());
            }
            return result;
        }
    }
}

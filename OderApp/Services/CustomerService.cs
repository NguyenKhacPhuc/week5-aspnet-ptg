using OderApp.DataSource.Entities;
using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;

namespace OderApp.Services
{

    public interface ICustomerService
    {
        public Task<List<Item>> GetMenu();
        public Task<List<Item>> GetMenuByCategory(string category);
        public Task<List<Item>> GetOrderedItemsByAccountId(int accountId);
        public Task<double> GetTotalCartPriceByAccountId(int accountId);
        public Task<List<Item>> OrderItems(List<KeyValuePair<string, int>> orderItems, int accountId);
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
        public async Task<List<Item>> GetMenu()
        {
            var result = new List<Item>();
            var menuEntities = await _menuRepository.GetAll();
            foreach (var menuEntity in menuEntities)
            {

                result.Add(menuEntity.ConvertToItemModel());
            }

            return result;
        }

        public async Task<List<Item>> GetMenuByCategory(string category)
        {
            var result = new List<Item>();
            var categoryId = (int)Enum.Parse(typeof(Models.Category), category.ToLower());
            var menuEntities = await _menuRepository.GetMenuByCategory(categoryId);
            foreach (var menuEntity in menuEntities)
            {
                result.Add(menuEntity.ConvertToItemModel());
            }

            return result;
        }

        public async Task<List<Item>> GetOrderedItemsByAccountId(int accountId)
        {
            var result = new List<Item>();
            var orderedItems = await _orderRepository.GetOrderedItemsByAccountId(accountId);
            foreach (var item in orderedItems)
            {
                result.Add(item.ConvertToItemModel());
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

        public async Task<List<Item>> OrderItems(List<KeyValuePair<string, int>> orderItems, int accountId)
        {
            var orderItemList = new List<OrderItem>();
            orderItems.ForEach(item => orderItemList.Add(new OrderItem(item.Key, item.Value)));
            var result = new List<Item>();
            var orderItemEntities = await _orderRepository.OrderItems(orderItemList, accountId);
            foreach (var itemEntity in orderItemEntities)
            {
                result.Add(itemEntity.ConvertToItemModel());
            }
            return result;
        }
    }
}

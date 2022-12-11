using System.Text.Json.Serialization;

namespace OderApp.DataSource.Entities
{
    public class OrderEntiy
    {
        [JsonPropertyName("accountId")]
        public int AccountId { get; set; }

        // OrderedItems[idItem, quantity]
        [JsonPropertyName("orderItems")]
        public List<OrderItem> OrderItems { get; set; }

        public OrderEntiy(int accountId, List<OrderItem> orderItems)
        {
            AccountId = accountId;
            OrderItems = orderItems;
        }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}

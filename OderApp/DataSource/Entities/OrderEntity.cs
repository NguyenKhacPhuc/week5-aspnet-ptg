using System.Text.Json.Serialization;

namespace OderApp.DataSource.Entities
{
    public class OrderEntity
    {
        [JsonPropertyName("accountId")]
        public int AccountId { get; set; }

        // OrderedItems[idItem, quantity]
        [JsonPropertyName("orderItems")]
        public List<OrderItem> OrderItems { get; set; }

        public OrderEntity(int accountId, List<OrderItem> orderItems)
        {
            AccountId = accountId;
            OrderItems = orderItems;
        }
    }

    public class OrderItem
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }

        public OrderItem(string itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }
    }
}

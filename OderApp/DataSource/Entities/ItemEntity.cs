namespace OderApp.DataSource.Entities
{
    public class ItemEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Category { get; set; }
        
        public ItemEntity(string id, string name, int quantity, double price, int category)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }
    }

    public enum Category
    {
        Food = 0,
        Drink = 1
    }
}

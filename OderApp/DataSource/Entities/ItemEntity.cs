namespace OderApp.DataSource.Entities
{
    public class ItemEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Catagory Catagory { get; set; }

        public ItemEntity(string id, string name, int quantity, double price, Catagory catagory)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Catagory = catagory;
        }
        public ItemEntity() { }
    }

    public enum Catagory
    {
        Food,
        Drink
    }
}

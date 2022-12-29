namespace OderApp.DataSource.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
        
        public ItemEntity(int id, string name, double price, int category)
        {
            Id = id;
            Name = name;
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

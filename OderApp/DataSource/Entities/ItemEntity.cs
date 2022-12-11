namespace OderApp.DataSource.Entities
{
    public class ItemEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }
    }

    public enum Category
    {
        food = 0,
        drinks = 1
    }
}

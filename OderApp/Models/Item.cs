using System;
namespace OderApp.Models
{
    public class Item
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public int Quantity { set; get; }

        public double Price { set; get; }

        public Catagory Catagory { set; get; }

        public Item(string id, string name, int quantity, double price, Catagory catagory)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Catagory = catagory;
        }
    }

    public enum Catagory
    {
        Food,
        Drink
    }
}


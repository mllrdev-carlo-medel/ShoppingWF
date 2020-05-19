using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Business.Entity
{
    public class Item
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = null;
        public float Price { get; set; } = -1;
        public int Stocks { get; set; } = -1;

        public Item()
        {

        }

        public Item(int id, string name, float price, int stocks)
        {
            Id = id;
            Name = name;
            Price = price;
            Stocks = stocks;
        }
    }
}

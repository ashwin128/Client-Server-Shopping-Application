using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Product
    {
        public string Name { get; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}

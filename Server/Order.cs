using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Order
    {
        public int OrderID { get; }
        public Account Account { get; }
        public Product Product { get; }
        public int Quantity { get; }

        public Order(int orderID, Account account, Product product, int quantity)
        {
            OrderID = orderID;
            Account = account;
            Product = product;
            Quantity = quantity;
        }
    }
}

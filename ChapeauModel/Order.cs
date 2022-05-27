using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }

        public List<OrderItem> orderItems;

        public DateTime timeTaken;

        public Order()
        {
            orderItems = new List<OrderItem>();
            timeTaken = new DateTime();
        }
    }
}

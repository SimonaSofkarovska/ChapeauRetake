using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }

        public List<OrderItem> orderItems { get; set; }

        public DateTime timeTaken;
        public int EmployeeID { get; set; }
        public int TableID { get; set; }

        public Order()
        {
            orderItems = new List<OrderItem>();
            timeTaken = new DateTime();
        }
    }
}

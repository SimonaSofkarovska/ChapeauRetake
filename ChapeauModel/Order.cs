using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Table Table { get; set; }

        public Employee Employee { get; set; }

        public DateTime TimeStamp { get; set; }

        //public bool Paid { get; set; }


    }
}

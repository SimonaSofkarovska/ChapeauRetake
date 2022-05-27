using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class OrderItem : MenuItem
    {
        public int OrderID { get; set; }

        public OrderStatus Status { get; set; }
    }
}

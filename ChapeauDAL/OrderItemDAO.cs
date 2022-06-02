using System;
using System.Collections.Generic;
using System.Text;
using ChapeauModel;

namespace ChapeauDAL
{
    public class OrderItemDAO
    {
        public void AddOrderItem(OrderItem orderItem)
        {
            string query = $"INSERT INTO Orderitem (OrderID, MenuID, Status, Requests";
        }
    }
}

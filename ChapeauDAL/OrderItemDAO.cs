﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ChapeauModel;

namespace ChapeauDAL
{
    public class OrderItemDAO:BaseDAO
    {
        public void AddOrderItem(OrderItem orderItem)
        {
            string query = "INSERT INTO Orderitem (OrderID, MenuID, Status, Requests, quantity) VALUES (@id, @menuid, @status, @requests, @quantity)";

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("id", orderItem.OrderID);
            parameters[1] = new SqlParameter("menuid", orderItem.ID);   //OrderItem inherits from menuitem, ID is the ID of the menu item
            parameters[2] = new SqlParameter("status", (int)orderItem.Status);
            parameters[3] = new SqlParameter("requests", orderItem.Requests);
            parameters[4] = new SqlParameter("quantity", orderItem.Quantity);

            ExecuteEditQuery(query, parameters);
        }
    }
}

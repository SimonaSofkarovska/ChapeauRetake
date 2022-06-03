using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ChapeauModel;

namespace ChapeauDAL
{
    public class OrderDAO:BaseDAO
    {
        public void AddOrder(Order order)
        {
            string query = "INSERT INTO [Order](OrderID, Timetaken, EmployeeID, Totalprice, Status, Tablenumber) VALUES(@OrderID, @Timetaken, @EmployeeID, @Totalprice, @Status, @Tablenumber)";

            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("OrderID", order.OrderID);
            parameters[1] = new SqlParameter("Timetaken", order.timeTaken);   //OrderItem inherits from menuitem, ID is the ID of the menu item
            parameters[2] = new SqlParameter("EmployeeID", order.EmployeeID);
            parameters[3] = new SqlParameter("Totalprice", order.TotalPrice);
            parameters[4] = new SqlParameter("Status", order.Status);
            parameters[5] = new SqlParameter("Tablenumber", order.TableNumber);

            ExecuteEditQuery(query, parameters);
        }
    }
}

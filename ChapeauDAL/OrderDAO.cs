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
            string query = "INSERT INTO Orders(Timetaken, EmployeeID, Totalprice, Status, Tablenumber) VALUES(@Timetaken, @EmployeeID, @Totalprice, @Status, @Tablenumber)";

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("Timetaken", order.timeTaken);   
            parameters[1] = new SqlParameter("EmployeeID", order.EmployeeID);
            parameters[2] = new SqlParameter("Totalprice", order.TotalPrice);
            parameters[3] = new SqlParameter("Status", order.Status);
            parameters[4] = new SqlParameter("Tablenumber", order.TableNumber);

            ExecuteEditQuery(query, parameters);
        }
    }
}

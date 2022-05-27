using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ChapeauModel;

namespace ChapeauDAL
{
    public class OrderDAO : BaseDAO
    {
        public List<Order> GetOrders(bool drinks, bool history)
        {
            try
            {
                string query = "SELECT DISTINCT(O.order_id), T.table_nr, O.[timeStamp], category_id, first_name, last_name " +
                               "FROM [ORDER] AS O " +
                               "JOIN [TABLE] AS T ON O.table_id = T.table_id " +
                               "JOIN EMPLOYEE AS E ON O.employee_id = E.employee_id " +
                               "JOIN ORDERITEM AS OI ON O.order_id = OI.order_id " +
                               "JOIN MENUITEM AS MI ON OI.item_id = MI.item_id " +
                               "WHERE OI.[status] ";
                query += (history ? "> 0 " : "= 0 ");
                query += "AND MI.category_id ";
                query += (drinks ? "> 30 " : "< 30 ");
                query += "ORDER BY O.[timeStamp]";
                query += (history ? "DESC; " : "; ");


                SqlParameter[] sqlParameters = new SqlParameter[0];
                return ReadOrders(ExecuteSelectQuery(query, sqlParameters));
            }
            catch (Exception ex)
            {
                //WriteToErrorLog(ex.ToString());
                return null;
            }
        }
        private List<Order> ReadOrders(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                order.Table = new Table();
                order.Employee = new Employee();
                {
                    order.OrderID = (int)dr["order_id"];
                    order.Table.TableNumber = (int)dr["table_nr"];
                    order.TimeStamp = (DateTime)dr["timeStamp"];
                    order.Employee.Name = (string)dr["first_name"];
                };
                orders.Add(order);
            }
            return orders;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ChapeauModel;
using System.Data.SqlClient;
using System.Data;

namespace ChapeauDAL
{
    public class OrderDAO:BaseDAO
    {
       
        public void AddOrder(Order order)
        {

        }
        // written by Simona
        public Order GetOrderByTableNr(int tableNr)
        {
            string query = $"select Orderitem.orderID, employeeID, Tablenumber,Timetaken, Status, Requests FROM[Order] JOIN Orderitem ON[Order].orderID = Orderitem.orderID JOIN Orderitems ON[Orderitems].itemID = OrderItem.itemID WHERE Tablenumber=@Tablenumber AND Status = 0";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("tableID", tableNr);

            List<Order> orders = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            if (orders.Count == 0)
            {
                return null;
            }
            else
            {
                return orders[0];
            }
        }
        // written by Simona
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            Order order = new Order();

            foreach (DataRow dr in dataTable.Rows)
            {

                OrderItem orderItem = new OrderItem();
                MenuItem menuItem = new MenuItem();

                menuItem.ID = (int)(dr["MenuID"]);
                menuItem.Name = (string)(dr["name"]);
                menuItem.Price = (double)(dr["price"]);
                menuItem.MealType = (MealType)(dr["MealType"]);
                menuItem.Type = (ItemType)(dr["itemType"]);


                orderItem.OrderID = (int)(dr["orderID"]);
 

                if (dr["Requests"] == DBNull.Value)
                {
                    orderItem.Comment = "";
                }
                else
                {
                    orderItem.Comment = (string)(dr["Requests"]);
                }

                orderItem.OrderTime = (DateTime)(dr["Timetaken"]);
                orderItem.OrderItemStatus = (OrderItemStatus)(dr["Status"]);
                orderItem.Item = menuItem;


                order.OrderID = (int)(dr["OrderID"]);
                order.EmployeeID = (int)(dr["EmployeeID"]);
                order.TableID = (int)(dr["Tablenumber"]);

                

                order.orderItems.Add(orderItem);

                orders.Add(order);
            }

            return orders;
        }
    }
}

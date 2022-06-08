using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string query = "INSERT INTO Orders(Timetaken, EmployeeID, Totalprice, Status, Tablenumber) VALUES(@Timetaken, @EmployeeID, @Totalprice, @Status, @Tablenumber)";

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("Timetaken", order.timeTaken);   
            parameters[1] = new SqlParameter("EmployeeID", order.EmployeeID);
            parameters[2] = new SqlParameter("Totalprice", order.TotalPrice);
            parameters[3] = new SqlParameter("Status", order.Status);
            parameters[4] = new SqlParameter("Tablenumber", order.TableNumber);

            ExecuteEditQuery(query, parameters);
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
        // written by Simona
        public List<Order> GetAllRunningOrders()
        {
            string query = "select OrderItem.orderID, employeeID, tableID, startTime, endTime, isPaid, Items.itemID, [count], [state], orderTime, comment, itemName, stock, price, itemType, itemSubType FROM[Order] JOIN OrderItem ON[Order].orderID = OrderItem.orderID JOIN Items ON[Items].itemID = OrderItem.itemID WHERE isPaid = 0 ORDER BY orderTime ";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Order> orders = ReadTablesRunningOrder(ExecuteSelectQuery(query, sqlParameters));

            return orders;
        }
        // written by Simona
        private List<Order> ReadTablesRunningOrder(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            return orders;
        }
    }
}

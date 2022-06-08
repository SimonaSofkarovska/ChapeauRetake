using System;
using System.Collections.Generic;
using System.Data;
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

        /*SELECT Orderitem.OrderID, [Menu].name, [Status].Status, Orderitem.Quantity, Orders.Tablenumber, Orders.Timetaken, Orders.Tablenumber, Orders.EmployeeID FROM Orders
JOIN Orderitem ON Orderitem.OrderID=Orders.OrderID
JOIN Menu ON OrderItem.MenuID=Menu.ID
JOIN [Status] ON Orderitem.Status=Status.ID
        */

        public List<Order> GetOrders() // ordernr table, employee time
        {
            try
            {
                string query = "SELECT Orderid, Tablenumber, Timetaken, EmployeeID FROM Orders";

                return ReadOrders(ExecuteSelectQuery(query));
            }
            catch (Exception ex)
            {
                WriteToErrorLog(ex.ToString());
                return null;
            }

        }

        private List<Order> ReadOrders(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                {
                    order.OrderID = (int)dr["OrderID"];
                    order.TableNumber = (int)dr["Tablenumber"];
                    order.timeTaken = (DateTime)dr["Timetaken"];
                    order.EmployeeID = (int)dr["EmployeeID"];
                };
                orders.Add(order);
            }
            return orders;
        }

        public List<OrderItem> GetOrderDetails(Order order)
        {
            string query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, Menu.Type, Menu.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                "FROM OrderItem " +
                "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                "WHERE OrderItem.OrderID = @ID ";


            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@ID", order.OrderID);
            //SqlParameter[] sqlParameters =
            //{
            //    new SqlParameter("@ID", order.OrderID),
            //};
            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<OrderItem> ReadOrderItem(DataTable dataTable)
        {
            List<OrderItem> OrderItems = new List<OrderItem>();
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderItem orderItem = new OrderItem();
                {
                    orderItem.Name = (string)dr["name"];
                    orderItem.Quantity = (int)dr["Quantity"];
                    orderItem.Status = (OrderStatus)((int)dr["Status"]);
                    orderItem.Requests = (string)dr["Requests"].ToString();
                    orderItem.ID = (int)dr["MenuID"];
                };
                OrderItems.Add(orderItem);
            }
            return OrderItems;
        }
        private Order ReadOrder(DataTable dataTable)
        {
            Order order = new Order();
            foreach (DataRow dr in dataTable.Rows)
            {
                {
                    order.OrderID = (int)dr["OrderID"];
                };
            }
            return order;
        }

        public void UpdateStatus(OrderItem orderItem, Order order)
        {
            string query = "UPDATE Orderitem SET [status] = @Status WHERE order_id = @OrderID AND item_id = @ItemID AND [timeStamp] = @TimeStamp;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("Status", (int)(orderItem.Status)),
                new SqlParameter("OrderID", order.OrderID),
                new SqlParameter("ItemID", orderItem.ID),
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateOrder(Order order, OrderItem orderItem)
        {
            string query = "INSERT INTO Orderitem (order_id, item_id, quantity, timetaken, status, requests) " +
                                          "VALUES( @OrderID, @ItemID, @Quantity, @Time, @Status, @Requests)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@OrderID", order.OrderID),
                new SqlParameter("@ItemID", orderItem.ID),
                new SqlParameter("@Quantity", orderItem.Quantity),
                new SqlParameter("@Timetaken", DateTime.Now),
                new SqlParameter("@Status", orderItem.Status),
                new SqlParameter("@Requests", orderItem.Requests),
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        //public int GenerateOrderNr()
        //{
        //    string query = "SELECT MAX(OrderID) AS result FROM Orders;";
        //    SqlParameter[] sqlParameters = new SqlParameter[0];

        //    return ReadCountData(ExecuteSelectQuery(query, sqlParameters)) + 1;
        //}

        //public void CreateOrderItems(Order order)
        //{
        //    string query = "INSERT INTO [ORDER] (order_id, table_id, employee_id, [timeStamp], paid) " +
        //                   "VALUES(@OrderID, @TableID, @EmployeeID, @TimeStamp, 0)";

        //    SqlParameter[] sqlParameters =
        //    {
        //        new SqlParameter("OrderID", order.OrderID),
        //        new SqlParameter("TableID", order.Table.TableID),
        //        new SqlParameter("EmployeeID", order.Employee.EmployeeID),
        //        new SqlParameter("TimeStamp", DateTime.Now),
        //    };
        //    ExecuteEditQuery(query, sqlParameters);
        //}

        public List<OrderItem> GetRunningOrder(Order order)
        {
            string query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, OrderItem.Type, OrderItem.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                "FROM OrderItem" +
                "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                "WHERE OrderItem.OrderID = @ID";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("OrderID", order.OrderID),
            };
            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }

        public Order GetByTable(Table table)
        {
            string query = "SELECT OrderID " +
                "FROM Orders " +
                "WHERE Tablenumber = @TableID;";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("TableID", table.TableId),
            };
            return ReadOrder(ExecuteSelectQuery(query, sqlParameters));
        }
    }
}

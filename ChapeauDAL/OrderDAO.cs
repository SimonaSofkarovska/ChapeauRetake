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

        /*SELECT Orderitem.OrderID, [Menu].name, [Status].Status, Orderitem.Quantity, [Order].Tablenumber, [Order].Timetaken, [Order].Tablenumber, [Order].EmployeeID FROM [Order]
            JOIN Orderitem ON Orderitem.OrderID=[Order].OrderID
            JOIN Menu ON OrderItem.MenuID=Menu.ID
            JOIN [Status] ON Orderitem.Status=Status.ID
        */

        public List<Order> GetOrders(bool drinks, bool allOrders)
        {
            try
            {
                string query = "SELECT Orders.OrderID, [Orders].Timetaken, [Orders].EmployeeID,[Status].Status, [Orders].Tablenumber,  FROM [Orders] " +
                               "FROM [ORDER] AS O " +
                               "JOIN [TABLE] AS T ON O.table_id = T.table_id " +
                               "JOIN EMPLOYEE AS E ON O.employee_id = E.employee_id " +
                               "JOIN ORDERITEM AS OI ON O.order_id = OI.order_id " +
                               "JOIN MENUITEM AS MI ON OI.item_id = MI.item_id " +
                               "WHERE OI.[status] ";
                query += (allOrders ? "> 0 " : "= 0 ");
                query += "AND MI.category_id ";
                query += (drinks ? "> 30 " : "< 30 ");
                query += (allOrders ? "DESC; " : "; ");


                SqlParameter[] sqlParameters = new SqlParameter[0];
                return ReadOrders(ExecuteSelectQuery(query, sqlParameters));
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
                    order.OrderID = (int)dr["order_id"];
                    order.TableNumber = (int)dr["table_nr"];
                    order.timeTaken = (DateTime)dr["timetaken"];
                    order.EmployeeID = (int)dr["employee_ id"];
                };
                orders.Add(order);
            }
            return orders;
        }

        public List<OrderItem> GetOrderDetails(Order order, bool drinks, bool allOrders)
        {
            string query = "SELECT [name], quantity, [timetaken], [status], requests, MI.item_id " +
                "FROM ORDERITEM AS OI " +
                "JOIN MENUITEM AS MI ON OI.item_id = MI.item_id " +
                "WHERE order_id = @ID AND MI.category_id ";
            query += (drinks ? "> 30 " : "< 30 ");
            query += "AND [status] ";
            query += (allOrders ? "> 0 " : "= 0 ");
            query += "ORDER BY [status], OI.[timetaken]; ";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("ID", order.OrderID),
            };
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
                    orderItem.Quantity = (int)dr["amount"];
                    orderItem.Status = (OrderStatus)((int)dr["status"]);
                    orderItem.Requests = (string)dr["remark"].ToString();
                    orderItem.ID = (int)dr["item_id"];
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
                    order.OrderID = (int)dr["order_id"];
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
                new SqlParameter("@Time", DateTime.Now),
                new SqlParameter("@Status", orderItem.Status),
                new SqlParameter("@requests", orderItem.Requests),
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        //public int GenerateOrderNr()
        //{
        //    string query = "SELECT MAX(order_id) AS result FROM[ORDER];";
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
            string query = "SELECT [name], quantity, [timetaken], [status], requests, MI.item_id " +
                "FROM ORDERITEM AS OI " +
                "JOIN MENUITEM AS MI ON OI.item_id = MI.item_id " +
                "WHERE order_id = @OrderID";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("OrderID", order.OrderID),
            };
            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }

        public Order GetByTable(Table table)
        {
            string query = "SELECT OrderID " +
                "FROM [Order] " +
                "WHERE Tablenumber = @TableID;";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("TableID", table.TableId),
            };
            return ReadOrder(ExecuteSelectQuery(query, sqlParameters));
        }
    }
}

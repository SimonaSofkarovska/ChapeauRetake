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
       
        public void AddOrder(int employeeid, int tablenumber)
        {
            string query =
                "INSERT INTO Orders(Timetaken, EmployeeID, Totalprice, Status, Tablenumber) " +
                "VALUES(@Timetaken, @EmployeeID, 0, 1, @Tablenumber)";

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("Timetaken", DateTime.Now);
            parameters[1] = new SqlParameter("EmployeeID", employeeid);
            parameters[2] = new SqlParameter("Tablenumber", tablenumber);

            ExecuteEditQuery(query, parameters);
        }
        // written by Simona, getting the table by a number
        public Order GetOrderByTableNr(int tableNr)
        {
            string query = $"select Orderitem.orderID, employeeID, Tablenumber,Timetaken, [Orders].Status, Requests FROM [Orders] JOIN Orderitem ON[Orders].orderID = Orderitem.orderID WHERE Tablenumber=@Tablenumber AND Orders.Status = 1";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Tablenumber", tableNr);

            List<Order> orders = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            if (orders.Count == 0)
            {
                return null;
            }
            
            return orders[0];
        }

       

        // written by Simona
        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            Order order = new Order();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem();

                menuItem.ID = (int)(dr["MenuID"]);
                menuItem.Name = (string)(dr["name"]);
                menuItem.Price = (double)(dr["price"]);
                menuItem.MealType = (MealType)(dr["MealType"]);
                menuItem.Type = (ItemType)(dr["type"]);

                OrderItem orderItem = new OrderItem(menuItem);

                orderItem.OrderID = (int)(dr["orderID"]);
                orderItem.Requests = (string)dr["Requests"];

                orderItem.OrderTime = (DateTime)(dr["Timetaken"]);
                orderItem.Status = (OrderStatus)(dr["Status"]);

                order.OrderID = (int)(dr["OrderID"]);
                order.EmployeeID = (int)(dr["EmployeeID"]);
                order.TableNumber = (int)(dr["Tablenumber"]);

                order.orderItems.Add(orderItem);

                orders.Add(order);
            }

            return orders;
        }
        public Order GetTablesCurrentOrder(int tableNumber)
        {

            string query = "SELECT OrderID, Timetaken, EmployeeID, Tablenumber, Totalprice, [Status] FROM Orders WHERE [Status] < 5 AND Tablenumber = @Tablenumber ";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("Tablenumber", tableNumber);


            List<Order> orders = ReadTables2(ExecuteSelectQuery(query, parameters));

            if (orders.Count > 0)
                return orders[0];

            return null;
        }

        public List<Order> ReadTables2(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                order.OrderID = (int)dr["OrderID"];
                order.timeTaken = (DateTime)dr["Timetaken"];
                order.EmployeeID = (int)dr["EmployeeID"];
                order.TableNumber = (int)dr["Tablenumber"];
                order.Status = (OrderStatus)(int)dr["Status"];

                orders.Add(order);
            }

            return orders;
        }
        // written by Simona
        public Order GetTablesRunningOrder(int tableNr)
        {
            string query = "SELECT Orderitem.OrderID, Orders.EmployeeID, Orders.Tablenumber, Orders.Timetaken, Orderitem.MenuID, Orderitem.Quantity, Orderitem.Status, Orderitem.Requests, Menu.name, Menu.type, Menu.Mealtype, Menu.price FROM Orders " +
                "JOIN OrderItem ON Orders.Orderid = OrderItem.OrderID " +
                "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                "WHERE Tablenumber = @Tablenumber AND Orders.Status < 5";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Tablenumber", tableNr);
            List<Order> orders = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            if (orders.Count > 0)
                return orders[0];

            return null;
        }
        public List<Order> GetRunningOrders()
        {
            string query = "SELECT Orderitem.OrderID, Orders.EmployeeID, Orders.Tablenumber, Orders.Timetaken, Orderitem.MenuID, Orderitem.Quantity, Orderitem.Status, Orderitem.Requests, Menu.name, Menu.type, Menu.Mealtype, Menu.price FROM Orders " +
                "JOIN OrderItem ON Orders.Orderid = OrderItem.OrderID " +
                "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                "WHERE  Orders.Status < 5";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            List<Order> orders = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            return orders;
        }


        public List<Order> GetOrders() // ordernr table, employee time
        {
            try
            {
                string query = "SELECT Orderid, Tablenumber, Timetaken, EmployeeID FROM Orders " +
                               "WHERE Status < 3 ";


                return ReadOrders(ExecuteSelectQuery(query));
            }
            catch (Exception ex)
            {
                WriteToErrorLog(ex.ToString());
                return null;
            }
        }
        public List<Order> GetOrdersHistory() 
        {
            try
            {
                string query = "SELECT Orderid, Tablenumber, Timetaken, EmployeeID, Status FROM Orders " +
                               "WHERE Timetaken >= @today AND STATUS >= 3";

                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@today", DateTime.Today)
                };

                return ReadOrders(ExecuteSelectQuery(query, sqlParameters));
            }
            catch (Exception ex)
            {
                WriteToErrorLog(ex.ToString());
                return null;
            }
        }
        public bool CheckOrderItemStatusOfOrder(int id)
        {
            string query = $"SELECT * FROM OrderItem WHERE OrderID = @OrderID AND Status < 3";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@OrderID", id);
            DataTable result = ExecuteSelectQuery(query, sqlParameters);

            if (result == null || result.Rows.Count < 1) // need to check for empty query
            {
                return true;
            }

            return false;
        }

        // this methode will help to update the status of an order  ruben needs to use this one
        public void UpdateOrderStatus(Order order)
        {
            try
            {
                if (CheckOrderItemStatusOfOrder(order.OrderID))
                {
                    order.Status = OrderStatus.Ready;
                    string query = $"UPDATE Orders set  Status = @Status  WHERE OrderID=@OrderID";
                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@OrderID", order.OrderID);
                    sqlParameters[1] = new SqlParameter("@Status", order.Status);

                    ExecuteEditQuery(query, sqlParameters);
                }
            }
            catch (Exception)
            {
                throw new Exception("Updating of status failed!");
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

        public List<OrderItem> GetOrderDetails(Order order, string type)
        {
            string query = null;
            if (type == "food")
            {
                query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, Menu.Type, Menu.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                            "FROM OrderItem " +
                            "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                            "WHERE OrderItem.OrderID = @ID AND OrderItem.Status < 3 AND Menu.Mealtype != 3 ";
            }
            else if (type == "drinks")
            {
                query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, Menu.Type, Menu.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                            "FROM OrderItem " +
                            "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                            "WHERE OrderItem.OrderID = @ID AND OrderItem.Status < 3 AND Menu.Mealtype = 3 ";
            }
                //and history

            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@ID", order.OrderID);
            return ReadOrderItem(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetOrderDetailsHistory(Order order, string type)
        {
            string query = null;
            if (type == "food")
            {
                query = $"SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, Menu.Type, Menu.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                            "FROM OrderItem " +
                            "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                            "WHERE OrderItem.OrderID = @ID AND Menu.Mealtype != 3";
            }
            else if (type == "drinks")
            {
                query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, Menu.Type, Menu.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
                            "FROM OrderItem " +
                            "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                            "WHERE OrderItem.OrderID = @ID AND Menu.Mealtype = 3 ";
            }
            //and history

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ID", order.OrderID)
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
                    orderItem.Quantity = (int)dr["Quantity"];
                    orderItem.Status = (OrderStatus)((int)dr["Status"]);
                    orderItem.Requests = (string)dr["Requests"].ToString();
                    orderItem.ID = (int)dr["MenuID"];
                    orderItem.MealType = (MealType)((int)dr["Mealtype"]);
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
            string query = "UPDATE OrderItem SET [Status] = @Status WHERE OrderID = @OrderID AND  OrderItem.MenuID = @ItemID ";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("Status", (int)(orderItem.Status)),
                new SqlParameter("OrderID", order.OrderID),
                new SqlParameter("ItemID", orderItem.ID),
            };
            ExecuteEditQuery(query, sqlParameters);
            UpdateOrderStatus(order);
        }

        //public void UpdateOrder(Order order, OrderItem orderItem)
        //{
        //    string query = "INSERT INTO OrderItem (OrderID, OrderItem.MenuID, Quantity, Status, requests, Timetaken) " + 
        //                                  "VALUES( @OrderID, @ItemID, @Quantity, @Time, @Status, @Requests)";
        //    SqlParameter[] sqlParameters =
        //    {
        //        new SqlParameter("@OrderID", order.OrderID),
        //        new SqlParameter("@ItemID", orderItem.ID),
        //        new SqlParameter("@Quantity", orderItem.Quantity),
        //        new SqlParameter("@Timetaken", DateTime.Now),
        //        new SqlParameter("@Status", orderItem.Status),
        //        new SqlParameter("@Requests", orderItem.Requests),
        //    };
        //    ExecuteEditQuery(query, sqlParameters);
        //}

        public List<OrderItem> GetRunningOrder()
        {
            //string query = "SELECT Menu.name, OrderItem.Quantity, OrderItem.Status, OrderItem.Type, OrderItem.Mealtype, OrderItem.Requests, OrderItem.MenuID " +
            //    "FROM OrderItem " +
            //    "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
            //    "WHERE OrderItem.OrderID = @ID";

            //SqlParameter[] sqlParameters =
            //{
            //    new SqlParameter("OrderID", order.OrderID),
            //};
            
            string query = $"select  Orderitem.orderID, employeeID, Tablenumber,Timetaken, [Orders].Status, Requests FROM [Orders] JOIN Orderitem ON[Orders].orderID = Orderitem.orderID WHERE Orders.Status < 5";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@Tablenumber", tableNr);
            List<OrderItem> order =  OrderItem(ExecuteSelectQuery(query, sqlParameters));
            return order;

        }
        private List<OrderItem> OrderItem(DataTable dataTable)
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
                    orderItem.OrderTime = (DateTime)dr["Timetaken"];
                    orderItem.ID = (int)dr["MenuID"];
                };
                OrderItems.Add(orderItem);
            }
            return OrderItems;
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
        public void UpdateOrderPrice(Order order)
        {
            string query = "UPDATE Orders SET Totalprice = @Totalprice WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("Totalprice", order.TotalPrice);
            parameters[1] = new SqlParameter("OrderID", order.OrderID);

            ExecuteEditQuery(query, parameters);
        }
        public void CancelOrder(Order order)
        {
            string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("OrderID", order.OrderID);

            ExecuteEditQuery(query, parameters);
        }
    }
}

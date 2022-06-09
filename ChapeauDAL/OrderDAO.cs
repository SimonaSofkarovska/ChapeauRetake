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
       
        public void AddOrder(int employeeid, int tablenumber)
        {
            Int32 orderID = 0;
            string sql =
                "INSERT INTO Orders(Timetaken, EmployeeID, Totalprice, Status, Tablenumber) " +
                "VALUES(@Timetaken, @EmployeeID, @Totalprice, @Status, @Tablenumber)" +
                "SELECT CAST(scope_identity() AS int) ";

            using (SqlConnection conn = new SqlConnection("Data Source=2122chapeau.database.windows.net; Initial Catalog = db_retake1; User = group_retake1; Password = vQj?(jK8uN19"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Timetaken", SqlDbType.DateTime);
                cmd.Parameters["@Timetaken"].Value = DateTime.Now;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Value = employeeid;
                cmd.Parameters.Add("@Totalprice", SqlDbType.Float);
                cmd.Parameters["@Totalprice"].Value = 0;
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = 1;
                cmd.Parameters.Add("@Tablenumber", SqlDbType.Int);
                cmd.Parameters["@Tablenumber"].Value = tablenumber;

                conn.Open();
                orderID = (Int32)cmd.ExecuteScalar();
            }
        }
        // written by Simona
        public Order GetOrderByTableNr(int tableNr)
        {
            string query = $"select Orderitem.orderID, employeeID, Tablenumber,Timetaken, Status, Requests FROM [Order] JOIN Orderitem ON[Order].orderID = Orderitem.orderID JOIN Orderitems ON [Orderitems].itemID = OrderItem.itemID WHERE Tablenumber=@Tablenumber AND Status = 0";
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

        public Order GetTablesCurrentOrder(int tableNumber)
        {
            string query = "SELECT OrderID, Timetaken, EmployeeID, Tablenumber, Totalprice, [Status] FROM Orders WHERE [Status] < 5";

            SqlParameter[] parameters = new SqlParameter[0];

            List<Order> orders = ReadTables2(ExecuteSelectQuery(query, parameters));

            /*if (orders[0] != null)
                return orders[0];*/

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


                if (dr["Requests"] == DBNull.Value)
                {
                    orderItem.Comment = "";
                }
                else
                {
                    orderItem.Comment = (string)(dr["Requests"]);
                }

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
        public List<Order> GetAllRunningOrders()
        {
            string query = "select Orderitem.OrderID, Orders.EmployeeID, Orders.Tablenumber, Orders.Timetaken, Orderitem.MenuID, Orderitem.Quantity, Orderitem.Status, Orderitem.Requests, Menu.name, Menu.type, Menu.Mealtype, Menu.price FROM Orders " +
                "JOIN OrderItem ON Orders.orderID = OrderItem.OrderID " +
                "JOIN Menu ON OrderItem.MenuID = Menu.ID " +
                "WHERE Orders.Status < 5";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Order> orders = ReadTablesRunningOrder(ExecuteSelectQuery(query, sqlParameters));

            return orders;
        }
        // written by Simona
        private List<Order> ReadTablesRunningOrder(DataTable dataTable)
        {
            return new List<Order>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class OrderService
    {
        private OrderDAO orderDAO;

        public OrderService()
        {
            orderDAO = new OrderDAO();
        }

        public Order GetOrderByTableNR(int tablenr)
        {
            Order order = orderDAO.GetOrderByTableNr(tablenr);
            return order;
        }
        public List<Order> GetAllRunningOrders()
        {
            List<Order> runningOrders = orderDAO.GetAllRunningOrders();
            return runningOrders;
        }
        public Order GetTablesCurrentOrder(int tableNumber)
        {
            return orderDAO.GetTablesCurrentOrder(tableNumber);
        }
        public List<Order> GetOrders()
        {
            return orderDAO.GetOrders();
        }
        public List<Order> GetOrdersHistory()
        {
            return orderDAO.GetOrdersHistory();
        }
        public List<OrderItem> GetOrderDetailsHistory(Order order, string type)
        {
            return orderDAO.GetOrderDetailsHistory(order, type);
        }
        public List<OrderItem> GetOrderDetails(Order order, string type)
        {
            return orderDAO.GetOrderDetails(order, type);
        }
        public void UpdateStatus(OrderItem orderItem, Order order)
        {
            orderDAO.UpdateStatus(orderItem, order);
        }
        public void UpdateOrderStatus(Order order)   //update the status of the order when a new item is added after completing the order
        {
            orderDAO.UpdateOrderStatus(order);
        }
        public void AddOrder(int employeeid, int tablenumber)
        {
            orderDAO.AddOrder(employeeid, tablenumber);
        }
        public void UpdatePrice(Order order)
        {
            orderDAO.UpdateOrderPrice(order);
        }

        public void CancelOrder(Order order)
        {
            orderDAO.CancelOrder(order);
        }

        public List<OrderItem> GetRunningOrder()
        {
            return orderDAO.GetRunningOrder();
        }
    }
}

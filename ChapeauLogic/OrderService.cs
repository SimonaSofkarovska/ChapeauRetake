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

        public void AddOrder(Order order)
        {
            orderDAO.AddOrder(order);
        }
        public List<Order> GetOrders()
        {
            return orderDAO.GetOrders();
        }

        public List<OrderItem> GetOrderDetails(Order order)
        {
            return orderDAO.GetOrderDetails(order);
        }
        public void UpdateStatus(OrderItem orderItem, Order order)
        {
            orderDAO.UpdateStatus(orderItem, order);
        }

        public void UpdateOrder(Order order, OrderItem orderItem)
        {
            orderDAO.UpdateOrder(order, orderItem);
        }

        //public int GenerateOrderNr()
        //{
        //    return orderDAO.GenerateOrderNr();
        //}

        //public void CreateOrderItems(Order order)
        //{
        //    orderDAO.CreateOrderItems(order);
        //}

        public Order GetByTable(Table table)
        {
            return orderDAO.GetByTable(table);
        }

        public List<OrderItem> GetRunningOrder(Order order)
        {
            return orderDAO.GetRunningOrder(order);
        }
    }
}

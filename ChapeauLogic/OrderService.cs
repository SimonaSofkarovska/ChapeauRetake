﻿using System;
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
        public List<Order> GetOrders(bool drinks)
        {
            return orderDAO.GetOrders(drinks);
        }

        public List<OrderItem> GetOrderDetails(Order order, bool drinks)
        {
            return orderDAO.GetOrderDetails(order, drinks);
        }
        public void UpdateStatus(OrderItem orderItem, Order order)
        {
            orderDAO.UpdateStatus(orderItem, order);
        }


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

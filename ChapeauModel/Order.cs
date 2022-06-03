using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }

        public List<OrderItem> orderItems;
        private double totalPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                double totalPrice = 0;
                foreach (OrderItem item in orderItems)
                    totalPrice += item.Price;

                this.totalPrice = totalPrice;
            }
        }

        public DateTime timeTaken;
        public int EmployeeID { get; set; }
        public int TableNumber { get; set; }
        public OrderStatus Status { get; set; }

        public Order(int OrderID, DateTime timeTaken, int EmployeeID, int TableNumber, OrderStatus Status)
        {
            orderItems = new List<OrderItem>();
            this.timeTaken = timeTaken;
            this.OrderID = OrderID;
            this.EmployeeID = EmployeeID;
            this.TableNumber = TableNumber;
            this.Status = Status;
        }


    }
}

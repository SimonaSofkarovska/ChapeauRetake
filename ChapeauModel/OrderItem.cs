using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class OrderItem : MenuItem
    {
        public int OrderID { get; set; }

        public OrderStatus Status { get; set; }

        public string Requests { get; set; }

        public int Quantity { get; set; }

        public OrderItem() {    /*  :)  */  }
        public OrderItem(int OrderID, int ID, OrderStatus Status, string Name, ItemType Type, MealType Mealtype, string Requests, double Price, int Quantity)
        public string Comment { get; set; }
        public DateTime OrderTime { get; set; }
        public  OrderItemStatus OrderItemStatus { get; set; }
        public MenuItem Item { get; set; }

        public OrderItem(int ID, string Name, ItemType Type, MealType Mealtype, double Price)
            :base(ID, Name, Type, Mealtype, Price)
        {
            this.OrderID = OrderID;
            this.Status = Status;
            this.Requests = Requests;
            this.Quantity = Quantity;
        }   
    }
}

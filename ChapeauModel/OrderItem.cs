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
        public OrderItem(int ID, OrderStatus Status, string Name, ItemType Type, MealType Mealtype, string Requests, double Price, int Quantity)
            :base(ID, Name, Type, Mealtype, Price)
        {
            this.Status = Status;
            this.Requests = Requests;
            this.Quantity = Quantity;
        }   
    }
}

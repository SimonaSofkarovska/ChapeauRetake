using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class OrderItem : MenuItem
    {
        public int OrderID { get; set; }

        public OrderStatus Status { get; set; }

        public string Comment { get; set; }
        public DateTime OrderTime { get; set; }
        public  OrderItemStatus OrderItemStatus { get; set; }
        public MenuItem Item { get; set; }

        public OrderItem(int ID, string Name, ItemType Type, MealType Mealtype, double Price)
            :base(ID, Name, Type, Mealtype, Price)
        {   // Required to make an order item with the data from the selected menu item when 
        }   // submitting an order
        public OrderItem()
        {

        }
    }
}

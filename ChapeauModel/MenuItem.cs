using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public ItemType Type { get; set; }
        public MealType MealType { get; set; }
        public double Price { get; set; }
    }
}

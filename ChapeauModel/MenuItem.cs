using System;
using System.Collections.Generic;
using System.Text;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int ItemID { get; set; }

        public MenuCategory Category { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double Vat { get; set; }

        public int Stock { get; set; }
    }
}

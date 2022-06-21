using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauDAL
{
    public class MenuDAO:BaseDAO
    {
        public List<MenuItem> GetMenu()
        {
            string query = "SELECT ID, name, type, price, Mealtype FROM Menu";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<MenuItem> Menu = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            return Menu;
        }
        public List<MenuItem> GetFilteredMenu(ItemType itemType, MealType mealType)
        {
            string query =
                "SELECT Menu.ID, Menu.name, Itemtype.type, menu.price, Mealtype.type FROM Menu" +
                "JOIN Itemtype ON Menu.[type] = Itemtype.ID" +
                "JOIN Mealtype ON Menu.Mealtype = Mealtype.ID" +
                "WHERE Itemtype.type = @itemType AND Mealtype.type != mealType";    //Mealtype has three values, lunch, dinner and others (drinks). If lunch menu is checked, items with mealtype dinner are not added

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("itemType", itemType.ToString());
            parameters[1] = new SqlParameter("mealType", mealType.ToString());

            return ReadTables(ExecuteSelectQuery(query, parameters));
        }
        public List<ItemType> GetItemTypes()
        {
            string query = "SELECT type FROM Itemtype ";

            SqlParameter[] parameters = new SqlParameter[0];

            return ReadTablesItemtype(ExecuteSelectQuery(query, parameters));
        }
        //public List<MenuCategory> GetDrinks()
        //{
        //    string query = "SELECT ID, name , type, price, Mealtype FROM Menu WHERE Mealtype = 3";

        //    SqlParameter[] sqlParameters = new SqlParameter[0];
        //    List<MenuItem> drinks = ReadTables(ExecuteSelectQuery(query, sqlParameters));
        //    return drinks;
        //}

        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> Menu = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem item = new MenuItem();

                item.ID = (int)(dr["ID"]);
                item.Name = (string)(dr["name"]);
                item.Type = (ItemType)dr["type"];
                item.MealType = (MealType)(dr["Mealtype"]);
                item.Price = (double)dr["price"];

                Menu.Add(item);
            }

            return Menu;
        }
        private List<ItemType> ReadTablesItemtype(DataTable table)
        {
            List<ItemType> types = new List<ItemType>();

            foreach (DataRow dr in table.Rows)
            {
                ItemType type = (ItemType)dr["type"];

                types.Add(type);
            }

            return types;
        }
    }
}

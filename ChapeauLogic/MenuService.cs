using System;
using System.Collections.Generic;
using System.Text;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class MenuService
    {
        private MenuDAO menuDAO;

        public MenuService()
        {
            menuDAO = new MenuDAO();
        }

        public List<MenuItem> GetMenu()
        {
            return menuDAO.GetMenu();
        }
        public List<MenuItem> GetFilteredMenu(ItemType itemType, MealType mealType)
        {
            return menuDAO.GetFilteredMenu(itemType, mealType);
        }
        public List<ItemType> GetItemTypes()
        {
            return menuDAO.GetItemTypes();
        }
    }
}

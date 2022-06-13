using ChapeauLogic;
using System;
using System.Windows.Forms;
using ChapeauModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        public MenuService menuService;
        public OrderService orderService;
        public OrderItemService orderItemService;

        private Employee employee;
        private Table table;
        private List<OrderItem> currentItems;
        private Order currentOrder;

        public WaiterView(Employee employee, Table table)
        {
            InitializeComponent();
            menuService = new MenuService();
            orderService = new OrderService();
            orderItemService = new OrderItemService();
            currentItems = new List<OrderItem>();

            if (orderService.GetTablesCurrentOrder(table.TableNumber) == null)
                orderService.AddOrder(employee.Id, table.TableNumber);

            currentOrder = orderService.GetTablesCurrentOrder(table.TableNumber);

            this.employee = employee;
            this.table = table;
        }

        private void WaiterView_Load(object sender, EventArgs e)
        {
            cmbMenu.DisplayMember = "Name";            

            for (int i = 1; i <= 10; i++)
                cmbQuantity.Items.Add($"{i}");

            cmbQuantity.SelectedIndex = 0;

            btnLunchMenu.Checked = true;

            LoadMenu(1);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddItem();

                cmbQuantity.SelectedIndex = 0;
                txtComments.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "An error has occured");
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(currentItems.Count == 0)
            {
                MessageBox.Show("Can not submit an empty order");
                return;
            }
            foreach (OrderItem orderItem in currentItems)
            {
                orderItemService.AddOrderItem(orderItem);
                currentOrder.orderItems.Add(orderItem);
            }

            if (currentOrder.Status == OrderStatus.Ready)      //This method is only required when the current order was marked as ready
                orderService.UpdateOrderStatus(currentOrder);

            CloseWindow();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lstCurrentOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected", "Select an item to remove from the order");
                return;
            }

            currentItems.Remove(currentItems[lstCurrentOrder.SelectedIndices[0]]);  //Removes the selected item from currentitems. 

            foreach (ListViewItem li in lstCurrentOrder.SelectedItems)
                lstCurrentOrder.Items.Remove(li);
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lstCurrentOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected", "Select an item to change the details");
                return;
            }

            ListViewItem newOrderItem = lstCurrentOrder.SelectedItems[0];           //Sets the values of the selected item to the current values of cmbQuantity and txtComments
            newOrderItem.SubItems[1].Text = cmbQuantity.SelectedItem.ToString();
            newOrderItem.SubItems[2].Text = txtComments.Text;

            currentItems[lstCurrentOrder.SelectedIndices[0]].Requests = newOrderItem.SubItems[2].Text;
            currentItems[lstCurrentOrder.SelectedIndices[0]].Quantity = int.Parse(newOrderItem.SubItems[1].Text);

            cmbQuantity.SelectedIndex = 0;
            txtComments.Text = "";
        }

        private void AddItem()      
        {
            if (!int.TryParse(cmbQuantity.SelectedItem.ToString(), out int amount))  //Check if the entered value for the amount of items is a number
                throw new Exception("Please select a valid amount");

            for (int i = 0; i < lstCurrentOrder.Items.Count; i++)
            {
                if (lstCurrentOrder.Items[i].Text == cmbMenu.Text)
                {
                    ListViewItem newListItem = lstCurrentOrder.Items[i];
                    lstCurrentOrder.Items[i].SubItems[1].Text = (int.Parse(lstCurrentOrder.Items[i].SubItems[1].Text) + amount).ToString();

                    return;
                }
            }

            MenuItem menuItem = (MenuItem)cmbMenu.SelectedItem;
            currentItems.Add(new OrderItem(currentOrder.OrderID, OrderStatus.New, txtComments.Text, amount, menuItem.ID, menuItem.Name, menuItem.Type, menuItem.MealType, menuItem.Price, DateTime.Now));

            ListViewItem listItem = new ListViewItem(menuItem.Name);
            listItem.SubItems.Add(cmbQuantity.SelectedItem.ToString());
            listItem.SubItems.Add(txtComments.Text);

            lstCurrentOrder.Items.Add(listItem);
        }

        private void LoadMenu(int menuItemType)
        {
            List<MenuItem> menu = menuService.GetMenu();
            List<MenuItem> filteredMenu = new List<MenuItem>();
            int mealType = 0;
            if (btnLunchMenu.Checked)
                mealType = 2;
            else
                mealType = 1;

            for (int i = 0; i < menu.Count; i++)
            {
                if (menu[i].Type == (ItemType)menuItemType && menu[i].MealType != (MealType)mealType)   //Mealtype has three values, 1 lunch, 2 dinner and 3 others (drinks). if lunch menu is checked, items with mealtype 2 (dinner items) are not added
                    filteredMenu.Add(menu[i]);
            }

            cmbMenu.DataSource = filteredMenu;
        }

        private void menuFilter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int itemType = 0;
            switch (e.ClickedItem.Text)
            {
                case "Starters":
                    itemType = 1;
                    break;
                case "Entrements":
                    itemType = 2;
                    break;
                case "Mains":
                    itemType = 3;
                    break;
                case "Desserts":
                    itemType = 4;
                    break;
                case "Soft drinks":
                    itemType = 5;
                    break;
                case "Beer":
                    itemType = 6;
                    break;
                case "Wine":
                    itemType = 7;
                    break;
                case "Spirit drinks":
                    itemType = 8;
                    break;
                case "Coffee/Tea":
                    itemType = 9;
                    break;
            }

            LoadMenu(itemType);
        }

        private void CloseWindow()
        {
            if (currentOrder.orderItems.Count == 0)
                orderService.CancelOrder(currentOrder);

            this.Close();
        }

        private void btnLunchMenu_CheckedChanged(object sender, EventArgs e)
        {
            if(btnLunchMenu.Checked == true)
                btnDinnerMenu.Checked = false;

            LoadMenu(1);
        }

        private void btnDinnerMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDinnerMenu.Checked == true)
                btnLunchMenu.Checked = false;

            LoadMenu(1);
        }
    }
}

using ChapeauLogic;
using System;
using System.Windows.Forms;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        public MenuService menuService;
        public OrderService orderService;
        public OrderItemService orderItemService;

        private List<MenuItem> currentItems;

        public WaiterView()
        {
            InitializeComponent();
            menuService = new MenuService();
            orderService = new OrderService();
            orderItemService = new OrderItemService();
            currentItems = new List<MenuItem>();
        }

        private void WaiterView_Load(object sender, EventArgs e)
        {
            cmbMenu.DisplayMember = "Name";
            cmbMenu.ValueMember = "ID";
            cmbMenu.DataSource = menuService.GetMenu();

            for (int i = 1; i <= 10; i++)
                cmbAmount.Items.Add($"{i}");

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)cmbMenu.SelectedItem;
            currentItems.Add(menuItem);
            ListViewItem listItem = new ListViewItem(menuItem.Name);
            listItem.SubItems.Add(cmbAmount.SelectedItem.ToString());
            listItem.SubItems.Add(txtComments.Text);

            lstCurrentOrder.Items.Add(listItem);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach(MenuItem menuItem in currentItems)
            {
                OrderItem orderItem = new OrderItem(menuItem.ID, menuItem.Name, menuItem.Type, menuItem.MealType, menuItem.Price);
                orderItemService.AddOrderItem(orderItem);
            }

            orderService.AddOrder()
        }
    }
}

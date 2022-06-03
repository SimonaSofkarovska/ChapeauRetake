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

        //private Employee employee;
        //private Table table;
        int employeeID = 1;
        int tablenumber = 2;
        private List<OrderItem> currentItems;

        public WaiterView(/*Employee employee, Table table*/)
        {
            InitializeComponent();
            menuService = new MenuService();
            orderService = new OrderService();
            orderItemService = new OrderItemService();
            currentItems = new List<OrderItem>();

            /*this.employee = employee;
            this.table = table;*/

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
            currentItems.Add(new OrderItem(2, menuItem.ID, OrderStatus.New, menuItem.Name, menuItem.Type, menuItem.MealType, txtComments.Text, menuItem.Price, int.Parse(cmbAmount.SelectedItem.ToString())));

            ListViewItem listItem = new ListViewItem(menuItem.Name);
            listItem.SubItems.Add(cmbAmount.SelectedItem.ToString());
            listItem.SubItems.Add(txtComments.Text);

            lstCurrentOrder.Items.Add(listItem);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Order order = new Order(2, DateTime.Now, employeeID, tablenumber/*employee.Id, table.TableNumber*/, OrderStatus.New);

            foreach(OrderItem orderItem in currentItems)
            {
                order.orderItems.Add(orderItem);
                orderItemService.AddOrderItem(orderItem);
            }

            orderService.AddOrder(order);

            MessageBox.Show("The order was succesfully submitted to the kitchen");

        }
    }
}

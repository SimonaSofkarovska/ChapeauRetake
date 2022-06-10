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

        /*private Employee employee;
        private Table table;*/
        private List<OrderItem> currentItems;
        private Order currentOrder;

        private int employeeid = 4;
        private int tablenumber = 2;

        public WaiterView(/*Employee employee, Table table*/)
        {
            InitializeComponent();
            menuService = new MenuService();
            orderService = new OrderService();
            orderItemService = new OrderItemService();
            currentItems = new List<OrderItem>();
            currentOrder = orderService.GetTablesCurrentOrder(tablenumber);

            if (currentOrder == null)
                orderService.AddOrder(/*employee.Id, table.TableNumber*/employeeid, tablenumber);

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

            cmbAmount.SelectedIndex = 0;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItem menuItem = (MenuItem)cmbMenu.SelectedItem;
                currentItems.Add(new OrderItem(currentOrder.OrderID, OrderStatus.New, txtComments.Text, int.Parse(cmbAmount.SelectedItem.ToString()), menuItem.ID, menuItem.Name, menuItem.Type, menuItem.MealType, menuItem.Price, DateTime.Now));

                ListViewItem listItem = new ListViewItem(menuItem.Name);
                listItem.SubItems.Add(cmbAmount.SelectedItem.ToString());
                listItem.SubItems.Add(txtComments.Text);

                lstCurrentOrder.Items.Add(listItem);
            }catch(Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach(OrderItem orderItem in currentItems)
                orderItemService.AddOrderItem(orderItem);

            MessageBox.Show("The order was sent to the kitchen");

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lstCurrentOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected", "Select an item to remove from the order");
                return;
            }

            for (int i = 0; i <= lstCurrentOrder.SelectedIndices.Count; i++)
                currentItems.Remove(currentItems[lstCurrentOrder.SelectedIndices[i]]);

            foreach (ListViewItem li in lstCurrentOrder.SelectedItems)
                lstCurrentOrder.Items.Remove(li);
        }
    }
}

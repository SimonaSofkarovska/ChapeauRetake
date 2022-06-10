using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class TableOverview : Form
    {
        private Employee employee;
        private TableService tableService;
        private OrderService orderService;
        private Order order;
        private OrderItemService orderItemService;
        public TableOverview(Employee employee)
        {
            tableService = new TableService();
            orderService = new OrderService();
            order = new Order();
            orderItemService = new OrderItemService();

            InitializeComponent();

            this.employee = employee;
            lblEmployee.Text = $"Signed in: {employee.Name} ({employee.Role})";

            //create timer 
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void btnSpecificTableOverview_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tableNr = Convert.ToInt32(button.Tag);
            if (tableNr < 1)
            {
                tableNr = 1;
            }
            btnAddItem.Tag = tableNr;
            btnSpecificTableOverview.Text = $"Table {tableNr}";

            Table selectedTable = tableService.GetTableByTableNR(tableNr);

            if (selectedTable.Status != TableStatus.Occupied)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to seat guests at table {tableNr}", "Seat guests", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tableService.UpdateStateTableToTrue(tableNr);
                    button.BackColor = Color.Red;                    
                    WaiterView waiterView = new WaiterView(/*employee,tableNr*/);
                    waiterView.Show();
                    RefreshTables();
                }
                else if (dialogResult == DialogResult.No)
                {
                    button.BackColor = Color.Green;
                }
            }
            else if (selectedTable.Status == TableStatus.Occupied)
            {
                btnAddItem.Show();
                btnPayForOrder.Show();

                //if the table has an order, create and start the timer
                if (selectedTable.Status == TableStatus.Ongoing)
                {
                    Timer timerWaitTime = new Timer();
                    timerWaitTime.Tick += timer_Tick;
                    timerWaitTime.Interval = 1000;
                    timerWaitTime.Start();
                }

                List<Order> orders = orderService.GetAllRunningOrders();

                if (order != null)
                {
                    foreach (OrderItem orderItem in order.orderItems)
                    {
                        ListViewItem li = new ListViewItem(orderItem.Name);
                        li.SubItems.Add(orderItem.Quantity.ToString());
                        li.SubItems.Add(orderItem.OrderTime.ToString("HH:mm:ss"));
                        listViewTableOrder.Items.Add(li);
                        listViewTableOrder.Show();
                        Console.WriteLine();
                    }                   
                }
            }
        }
       
        void timer_Tick(object sender, EventArgs e)
        {
            RefreshIcons();
            RefreshTables();
        }
        //refresh the tables
        private void RefreshTables()
        {
            
            List<Table> tables = tableService.GetAllTables();
            Button[] buttons = new Button[] { btnTable1, btnSpecificTableOverview, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };

            int i = 0;
            foreach (Table table in tables)
            {
                if (table.Status==TableStatus.Occupied)
                {
                    buttons[i].BackColor = Color.Red;
                }
                else if (table.Status == TableStatus.Reserved)
                {
                    buttons[i].BackColor = Color.Orange;
                }
                else 
                {
                    buttons[i].BackColor = Color.Green;
                }

                i++;
            }
        }
        //refresh the icons
        private void RefreshIcons()
        {
            PictureBox[] readyIcons = new PictureBox[] { readyTable1, readyTable2, readyTable3, readyTable4, readyTable5, readyTable6, readyTable7, readyTable8, readyTable9, readyTable10 };
            PictureBox[] preparingIcons = new PictureBox[] { preparingTable1, preparingTable2, preparingTable3, preparingTable4, preparingTable5, preparingTable6, preparingTable7, preparingTable8, preparingTable9, preparingTable10 };

            OrderService orderService = new OrderService();
            List<Order> runningOrders = orderService.GetAllRunningOrders();

            try
            {
                order = runningOrders[0];
                int i = 0;
                foreach (Order o in runningOrders)
                {

                    foreach (OrderItem item in o.orderItems)
                    {
                        if (item.Status == OrderStatus.Preparing)
                            preparingIcons[o.TableNumber - 1].Show();


                        if (item.Status == OrderStatus.Ready)
                            readyIcons[o.TableNumber - 1].Show();
                    }
                    i++;
                }
            }
            catch
            {
                Console.WriteLine("Could not refresh!");
            }            
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            //when the readyicon is clicked menas that the orderItem is ready to be served

            PictureBox icon = (PictureBox)sender;
            int tableNR = Convert.ToInt32(icon.Tag);

             orderItemService = new OrderItemService();
             orderService = new OrderService();
            if (tableNR < 1)
            {
                tableNR = 1;
            }
            DialogResult dialogResult = MessageBox.Show($"Do you want to update the food status from preparing to served for table {tableNR}?", "Serve food", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                order = orderService.GetOrderByTableNR(tableNR);
                orderItemService.UpdateOrderState(tableNR, order.OrderID);
                icon.Hide();
            }
        }
    }
}

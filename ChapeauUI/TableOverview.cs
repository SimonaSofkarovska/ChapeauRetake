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
        TableService tableService;
        public TableOverview(Employee employee)
        {
            tableService = new TableService();

            InitializeComponent();

            this.employee = employee;
            lblEmployee.Text = $"Signed in: {employee.Name} ({employee.Role})";

            //create timer 
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000;
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
            btnAddItem.Tag = tableNr;

            btnSpecificTableOverview.Text = $"Table {tableNr}";

           // TableService tableService = new TableService();
            // OrderService orderService = new OrderService();

            //get state table
            Table selectedTable = tableService.GetTableByTableNR(tableNr);

            if (!selectedTable.Status)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to seat guests at table {tableNr}", "Seat guests", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tableService.UpdateStateTableToTrue(tableNr);
                    button.BackColor = Color.PaleTurquoise;
                    RefreshTables();
                }
                else if (dialogResult == DialogResult.No)
                {
                    button.BackColor = Color.Gainsboro;
                }
            }
            else
            {
                btnAddItem.Show();
                btnPayForOrder.Show();

                //listViewTableOrderOverview.Items.Clear();

                // order = new Order();

                // order = orderService. get an order by specific table


                //if (order != null)
                {
                    //foreach (OrderItem orderItem in order.orderedItems)
                    //{
                    //    ListViewItem li = new ListViewItem(orderItem.Item.ItemName);
                    //    li.SubItems.Add(orderItem.Quantity.ToString());
                    //    listViewTableOrderOverview.Items.Add(li);

                    //}
                }
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // ...
        }
        private void RefreshTables()
        {
            
            List<Table> tables = tableService.GetAllTables();
            Button[] buttons = new Button[] { btnTable1, btnSpecificTableOverview, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };

            int i = 0;
            foreach (Table table in tables)
            {
                if (table.Status)
                {
                    buttons[i].BackColor = Color.Red;
                }
                else
                {
                    buttons[i].BackColor = Color.Green;
                }

                i++;
            }

        }
        private void RefreshIcons()
        {
            PictureBox[] readyIcons = new PictureBox[] { readyTable1, readyTable2, readyTable3, readyTable4, readyTable5, readyTable6, readyTable7, readyTable8, readyTable9, readyTable10 };
            PictureBox[] preparingIcons = new PictureBox[] { preparingTable1, preparingTable2, preparingTable3, preparingTable4, preparingTable5, preparingTable6, preparingTable7, preparingTable8, preparingTable9, preparingTable10 };

            for (int j = 0; j < 10; j++)
            {
                readyIcons[j].Hide();
                preparingIcons[j].Hide();
            }


           // OrderService orderService = new OrderService();
           // List<Order> runningOrders = orderService.GetAllRunningOrders();

            //Order currentOrder = runningOrders[0];

            //int i = 0;
            //foreach (Order o in runningOrders)
            //{

            //    foreach (OrderItem item in o.orderedItems)
            //    {
            //        if (item.State == State.Preparing)
            //        {
            //            preparingIcons[o.TableID - 1].Show();
            //        }

            //        if (item.State == State.Done)
            //        {
            //            readyIcons[o.TableID - 1].Show();
            //        }
            //    }

            //    i++;
            //}
        }

        private void readyTable2_Click(object sender, EventArgs e)
        {
            //when the readyicon is clicked => update state orderitems to served

            PictureBox icon = (PictureBox)sender;
            int tableNR = Convert.ToInt32(icon.Tag);

            //OrderItemService orderItemservice = new OrderItemService();
           // OrderService orderservice = new OrderService();

            DialogResult dialogResult = MessageBox.Show($"Do you want to update the food status from preparing to served for table {tableNR}?", "Serve food", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
               // Order order = orderservice.GetOrderByTableNR(tableNr);
                //orderItemservice. update or sth
                icon.Hide();
            }
        }
    }
}

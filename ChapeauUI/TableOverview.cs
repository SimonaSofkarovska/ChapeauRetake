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
    public partial class listViewTableOrderOverview : Form
    {
        private Employee employee;
        private TableService tableService;
        private Table table;
        // private Order order;
        public listViewTableOrderOverview(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            lblEmployee.Text = $"Signed in: {employee.Name} ({employee.Role})";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void btnTable2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int tableNr = Convert.ToInt32(button.Tag);
            btnAddItem.Tag = tableNr;

            btnTable2.Text = $"Table {tableNr}";

            TableService tableService = new TableService();
            // OrderService orderService = new OrderService();

            //get state table
            Table selectedTable = tableService.GetTableByTableNR(tableNr);

            if (!selectedTable.IsOccupied)
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

                // order = orderService.GetOrderByTableNR(tableNr);


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
        private void RefreshTables()
        {
            TableService tableService = new TableService();
            List<Table> tables = tableService.GetAllTables();
            Button[] buttons = new Button[] { btnTable1, btnTable2, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };

            int i = 0;
            foreach (Table table in tables)
            {
                if (table.IsOccupied)
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

    }
}

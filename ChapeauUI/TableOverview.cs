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
        private Table selectedTable;    //Made it a private field so btnAddItem can access the selected table

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
            Timer timer = new Timer();
            timer.Interval = 2000;
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
            Console.WriteLine(button.Tag); 
            int tableNr = Convert.ToInt32(button.Tag);
            Console.WriteLine(tableNr);
            if (tableNr < 1)
            {
                tableNr = 1;
            }
            btnAddItem.Tag = tableNr;

            //get table from db
            this.selectedTable = tableService.GetTableByTableNR(tableNr);
            Console.WriteLine(selectedTable);
            if (selectedTable.Status != TableStatus.Occupied)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to seat guests at table {tableNr}", "Seat guests", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tableService.UpdateStateTableToTrue(tableNr);
                    button.BackColor = Color.Red;                    
                    WaiterView waiterView = new WaiterView(employee, selectedTable);
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
                    timerWaitTime.Interval = 3000;
                    timerWaitTime.Start();
                }

                List<Order> orders = orderService.GetAllRunningOrders();
                selectedTable = tableService.GetTableByTableNR(tableNr);

                if (selectedTable != null)
                {

                    List<Order> orderOfTable = orderService.GetAllRunningOrders();
                    listViewTableOrder.Items.Clear();

                    // Show the orderedItems from the Order class.
                    if (order != null)
                    {
                        foreach (OrderItem o in order.orderItems)
                        {
                            ListViewItem li = new ListViewItem(o.Name);
                            li.SubItems.Add(o.Status.ToString());
                            li.SubItems.Add(o.OrderTime.ToString("HH:mm:ss"));
                            li.SubItems.Add(o.TableNumber.ToString());
                            listViewTableOrder.Items.Add(li);
                            listViewTableOrder.Show();
                            Console.WriteLine();
                        }
                    }
                    
                }
                
            }
        }
       
    void timer_Tick(object sender, EventArgs e)
        {           
            // If problems occure with unwanted updates of the table, comment out the RefreshIcons();
            RefreshIcons();
            RefreshTables();
        }
        //refresh the tables
        private void RefreshTables()
        {
            
            List<Table> tables = tableService.GetAllTables();
            Button[] buttons = new Button[] { btnTable1, btnSpecificTableOverview, btnTable3, btnTable4, btnTable5, btnTable6, btnTable7, btnTable8, btnTable9, btnTable10 };

            foreach (Table table in tables)
            {
                foreach (Button button in buttons)
                {
                    // Check if the button Tag matches the table number in the database

                    if (button.Tag.ToString() == table.TableNumber.ToString())
                    {
                        // For optimasation create a load method, that adds the corresponding table number to the button once.
                        // Using the line below like this updates the button text of the table every 2.5s.
                        // Make the Button text values equal to the TableNumber from the database.
                        button.Text = table.TableNumber.ToString();

                        if (table.Status == TableStatus.Occupied)
                        {
                            button.BackColor = Color.Red;
                        }
                        else if (table.Status == TableStatus.Reserved)
                        {
                            button.BackColor = Color.Orange;
                        }
                        else
                        {
                            button.BackColor = Color.Green;
                        }
                    }                   
                    
                }
            }
        }
        //refresh the icons
        private void RefreshIcons()
        {
            PictureBox[] readyIcons = new PictureBox[] { readyTable1, readyTable2, readyTable3, readyTable4, readyTable5, readyTable6, readyTable7, readyTable8, readyTable9, readyTable10 };
            PictureBox[] preparingIcons = new PictureBox[] { preparingTable1, preparingTable2, preparingTable3, preparingTable4, preparingTable5, preparingTable6, preparingTable7, preparingTable8, preparingTable9, preparingTable10 };

            //get all orders from db 
            OrderService orderService = new OrderService();
            List<Order> runningOrders = orderService.GetAllRunningOrders();
            
            try
            {
                order = runningOrders[0];

                foreach (Order o in runningOrders)
                {

                    foreach (OrderItem item in o.orderItems)
                    {
                        if (item.Status == OrderStatus.Preparing)
                            preparingIcons[o.TableNumber - 1].Show();


                        if (item.Status == OrderStatus.Ready)
                            readyIcons[o.TableNumber - 1].Show();
                    }
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Do you want to add new items to the order for table {this.selectedTable.TableNumber}", "Add item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                WaiterView waiterView = new WaiterView(employee, this.selectedTable);
                waiterView.Show();
            }
        }
    }
}
//private void createTableButtons()
//{
//    List<Table> tables = tableService.GetAllTables();
//    // the location is an array of points that are the position for all the buttons.
//    var locations = new Point[] { new Point(25, 212) };



//    int index = 0;
//    foreach (Table table in tables)
//    {
//        // To make the buttons not hardcoded anymore we create them in this method, we loop over the table data and add the tableNr as the button text and the Tag.
//        // Thevalues below are the styling of the button, and the names should be equal to the once used in the funciton below for refreshing
//        // The Click object should be equal to the function btnSpecficTablesOverviewClick to fire the needed functionality.

//        // We could have used a FlowLayoutPanel to add the button withouteed to specify the locations,
//        // but this would mean we had to remove the icons next to it, or create subgroup to keep the icons next to the buttons.
//        // Due to limitted time we decided to try to keep the application close to the design of the Figma prototype.

//        /*
//        this.newButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
//        this.newButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//        this.newButton.Location = new System.Drawing.Point(25, 212);
//        this.newButton.Name = "btnTable1";
//        this.newButton.Size = new System.Drawing.Size(120, 70);
//        this.newButton.TabIndex = 11;
//        this.newButton.Tag = "table.TableNumber";
//        this.newButton.Text = "table.TableNumber";
//        this.newButton.UseVisualStyleBackColor = false;
//        this.newButton.Click += new System.EventHandler(this.btnSpecificTableOverview_Click); */
//        Button newButton = new Button();
//        newButton.Text = "test " + table.TableNumber.ToString();
//        // newButton.Click += btnSpecificTableOverview_Click
//        newButton.Size = new Size(70, 120);
//        newButton.Location = locations[0];

//        // Add buttons to the Control so they show up on the page.
//        this.Controls.Add(newButton);
//        ++index;
//    }
//}

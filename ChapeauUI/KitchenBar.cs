using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChapeauDAL;
using ChapeauLogic;
using System.IO;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        OrderService orderService = new OrderService();
        private Employee employee;

        public KitchenBar(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;


            lblUser.Text = $"User: {employee.Name}";

            btn_mrkready.Enabled = false;
            btn_Preparing.Enabled = false;
            btn_Undo.Enabled = false;
            LoadOrders();
        }
        private void LoadOrders()
        {
            try
            {
                ShowHeadline();
                btn_mrkready.Show();
                btn_Preparing.Show();
                lvOrderDetail.Items.Clear();

                List<Order> ordersList = orderService.GetOrders();
                ShowOrders(ordersList);
            }
            catch (Exception exeption)
            {
                ErrorProcess(exeption, "Something went wrong while loading the orders");
            }
        }
        private void ShowOrders(List<Order> orders)
        {
            try
            {
                btn_Undo.Show();
                btn_Preparing.Show();
                lvOrders.Items.Clear();
                foreach (Order order in orders)
                {
                    ListViewItem lv = new ListViewItem(order.OrderID.ToString());
                    lv.SubItems.Add(order.TableNumber.ToString());
                    lv.SubItems.Add(order.timeTaken.ToString("HH:mm"));//maybe add the diff between time.now and timetaken had problems while subtracting time.now cu timetaken
                    lv.SubItems.Add(order.EmployeeID.ToString());
                    lv.Tag = order;
                    lvOrders.Items.Add(lv);
                }
            }
            catch (Exception exeption)
            {
                ErrorProcess(exeption, "Something went wrong while loading the items");
            }
        }
        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHeadline();

            btn_mrkready.Enabled = ((lvOrders.SelectedItems.Count > 0));
            btn_Preparing.Enabled = ((lvOrders.SelectedItems.Count > 0));
            btn_Undo.Enabled = ((lvOrders.SelectedItems.Count > 0));

            if (lvOrders.SelectedItems.Count > 0)
            {
                Order order = (Order)lvOrders.SelectedItems[0].Tag;
                ShowOrderDetailes(order);
            }
        }
        private void ShowOrderDetailes(Order order)
        {
            try
            {
                List<OrderItem> orderItems = Filter(order);
                lvOrderDetail.Items.Clear();

                foreach (OrderItem item in orderItems)
                {
                    ListViewItem lv = new ListViewItem(item.Name.ToString());
                    lv.SubItems.Add(item.Quantity.ToString());
                    lv.SubItems.Add(item.Status.ToString());
                    lv.SubItems.Add(order.timeTaken.ToString("HH:mm:ss"));
                    lv.SubItems.Add(item.Requests.ToString());
                    lv.Tag = item;
                    lvOrderDetail.Items.Add(lv);
                }
            }
            catch (Exception exeption)
            {
                ErrorProcess(exeption, "Something went wrong while loading the orders");
            }
        }
        public List<OrderItem> Filter(Order order)
        {
            List<OrderItem> filterOI = new List<OrderItem>();
            List<OrderItem> orderItems = orderService.GetOrderDetails(order);
            if (employee.Role==Role.Barman)
            {
                foreach (OrderItem item in orderItems)
                {
                    if (item.MealType == MealType.Other)
                    {
                        filterOI.Add(item);
                    }
                }

            }
            else
            {
                foreach(OrderItem item in orderItems)
                {
                    if (item.MealType != MealType.Other)
                    {
                        filterOI.Add(item);
                    }
                }
            }
            return filterOI;

        }

        private void ShowHeadline()
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm\ndd/MM/yyyy");

            if (employee.Role==Role.Barman)
            {
                this.Text = "Bar";
                lblwhat.Text = "Bar";
            }
            else
            {
                this.Text = "Kitchen";
                lblwhat.Text = "Kitchen";
            }
        }

        private void btn_mrkready_Click(object sender, EventArgs e)
        {
            ChangeItemStatus("Attention!", $"No specific items were selected, Therefore all items in the order will be marked as READY.\nProceed?", OrderStatus.Ready);
        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
        private void btn_Undo_Click(object sender, EventArgs e)
        {
            ChangeItemStatus("Attention!", $"No specific items were selected, Therefore all items in the order will be marked back as NEW.\nProceed?", OrderStatus.New);
        }
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
            login.Closed += (s, args) => this.Close();
        }
        private void btn_Preparing_Click(object sender, EventArgs e)
        {
            ChangeItemStatus("Attention!", $"No specific items were selected, Therefore all items in the order will be marked back as PREPARING.\nProceed?", OrderStatus.Preparing);
        }
        private void ChangeItemStatus(string headline, string message, OrderStatus orderStatus)
        {
            Order order = (Order)lvOrders.SelectedItems[0].Tag;

            if (lvOrderDetail.SelectedItems.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show(message, headline, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<OrderItem> orderItems = orderService.GetOrderDetails(order);
                    foreach (OrderItem item in orderItems)
                    {
                        item.Status = orderStatus;
                        orderService.UpdateStatus(item, order);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                for (int i = 0; i < lvOrderDetail.SelectedItems.Count; i++)
                {
                    OrderItem item = (OrderItem)lvOrderDetail.SelectedItems[i].Tag;
                    item.Status = orderStatus;
                    orderService.UpdateStatus(item, order);
                }
            }
            LoadOrders();
        }



        private void ErrorProcess(Exception exception, string messege)
        {
            MessageBox.Show(messege, "Error occured");

            StreamWriter error = File.AppendText("..\\..\\..\\Error Log.txt");
            error.WriteLine($"Error occured at: {DateTime.Now}:");
            error.WriteLine(messege);
            Console.WriteLine(exception);
            Console.WriteLine();
            error.Close();
        }

        private void lvOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}

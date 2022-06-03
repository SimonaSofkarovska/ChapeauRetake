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
        private bool drinks = false;
        private bool AllOrders = false;

        public KitchenBar(Employee employee)
        {
            InitializeComponent();

            if (employee.Roles == Role.Barman)
            {
                drinks = true;
            }

            lblUser.Text = $"User: {employee.Name}";

            btn_mrkready.Enabled = false;
            LoadOrders(AllOrders, drinks);
        }
        private void LoadOrders(bool AllOrders, bool drinks)
        {
            try
            {
                ShowHeadline();
                btn_mrkready.Show();
                lvOrderDetail.Items.Clear();

                List<Order> ordersList = orderService.GetOrders(drinks, AllOrders);
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
                lvOrders.Items.Clear();
                foreach (Order order in orders)
                {
                    ListViewItem li = new ListViewItem(order.OrderID.ToString());
                    li.SubItems.Add(order.TableNumber.ToString());
                    li.SubItems.Add(order.timeTaken.ToString("HH:mm"));
                    //li.SubItems.Add(order.Employee.Name);
                    li.Tag = order;
                    lvOrders.Items.Add(li);
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

            if (lvOrders.SelectedItems.Count > 0)
            {
                Order order = (Order)lvOrders.SelectedItems[0].Tag;
                ShowItems(order, drinks, AllOrders);
            }
        }
        private void ShowItems(Order order, bool drinks, bool AllOrders)
        {
            try
            {
                List<OrderItem> orderItems = orderService.GetItems(order, drinks, AllOrders);
                lvOrderDetail.Items.Clear();

                foreach (OrderItem item in orderItems)
                {
                    ListViewItem li = new ListViewItem(item.Name.ToString());
                    li.SubItems.Add(item.Quantity.ToString());
                    li.SubItems.Add(item.Status.ToString());
                    //li.SubItems.Add(item..ToString("HH:mm:ss"));
                    li.SubItems.Add(item.Requests.ToString());
                    li.Tag = item;
                    lvOrderDetail.Items.Add(li);
                }
            }
            catch (Exception exeption)
            {
                ErrorProcess(exeption, "Something went wrong while loading the orders");
            }
        }

        private void ShowHeadline()
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm\ndd/MM/yyyy");

            if (drinks)
            {
                this.Text = "Bar";
                lblwhat.Text = "Bar";
            }
            else
            {
                this.Text = "Kitchen";
                lblwhat.Text = "Kitchen";
            }
            if (AllOrders)
            {
                this.Text += " All Orders";
                lblwhat.Text += " All Orders";
            }
        }

        private void btn_mrkready_Click(object sender, EventArgs e)
        {
            ChangeItemStatus("Attention!", $"No specific items were selected, Therefore all items in the order will be marked as READY.\nProceed?", OrderStatus.Done);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            AllOrders = false;
            LoadOrders(AllOrders, drinks);
        }


        private void ChangeItemStatus(string headline, string message, OrderStatus orderStatus)
        {
            Order order = (Order)lvOrders.SelectedItems[0].Tag;

            if (lvOrderDetail.SelectedItems.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show(message, headline, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<OrderItem> orderItems = orderService.GetOrderDetails(order, drinks, AllOrders);
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
            LoadOrders(AllOrders, drinks);
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

        private void btn_AllOrders_Click(object sender, EventArgs e)
        {

        }
    }
}

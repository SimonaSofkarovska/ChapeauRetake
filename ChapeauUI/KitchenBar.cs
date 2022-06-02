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

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        //OrderService orderService = new OrderService();
        //private bool drinks = false;
        //private bool history = false;

        public KitchenBar(Employee employee)
        {
            InitializeComponent();

            if (employee.Role == Role.Waiter)
            {
                //drinks = true;
            }

            //lblUsername.Text = $"User: {employee.DisplayName}";

            //btnReady.Enabled = false;
            //btnUndo.Enabled = false;
            //LoadOrders(history, drinks);
        }
    }
}

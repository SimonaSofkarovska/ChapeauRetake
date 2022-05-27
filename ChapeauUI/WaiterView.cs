using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class WaiterView : Form
    {
        public MenuService service;

        public WaiterView()
        {
            InitializeComponent();
            service = new MenuService();
        }

        private void WaiterView_Load(object sender, EventArgs e)
        {
            cmbMenu.DisplayMember = "Name";
            cmbMenu.ValueMember = "ID";
            cmbMenu.DataSource = service.GetMenu();
        }
    }
}

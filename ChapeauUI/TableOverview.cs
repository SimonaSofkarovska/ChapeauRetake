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
        private int tableNumber;
        public TableOverview(Employee employee)
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

        private void TableOverview_Load(object sender, EventArgs e)
        {
            List<Table> tables = tableService.GetAll();
            List<Button> buttons = new List<Button>
            {
                btnTable1, btnTable2,
                btnTable3, btnTable4,
                btnTable5, btnTable6,
                btnTable7, btnTable8,
                btnTable9, btnTable10
            };
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Tag = tables[i];
                switch (tables[i].Status)
                {
                    case TableStatus.Occupied:
                        buttons[i].BackColor = Color.Red;
                        break;
                    case TableStatus.Empty:
                        buttons[i].BackColor = Color.Green;
                        break;                    
                    case TableStatus.Reserved:
                        buttons[i].BackColor = Color.Orange;
                        break;
                }
            }
        }
    }
}

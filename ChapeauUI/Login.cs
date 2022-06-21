using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;


namespace ChapeauUI
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckRole(txtboxUsername.Text, txtboxPassword.Text);
        }
        //verify user
        //open the right forms according to the employee role
        private void CheckRole(string username, string password)
        {
            Employee employee;
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.Login(username, password);

            if (employee.Role == Role.Manager || employee.Role == Role.Waiter)
            {
                Form tableOverview = new TableOverview(employee);
                this.Hide();
                tableOverview.ShowDialog();
            }
            else if (employee.Role == Role.Barman || employee.Role == Role.Chef)
            {
                KitchenBar kitchenBarView = new KitchenBar(employee);
                this.Hide();
                kitchenBarView.Show();
            }
            else
            {
                MessageBox.Show($"User does not exist!");
                txtboxUsername.Text = string.Empty;
                txtboxPassword.Text = string.Empty;
                return;
            }

        }
    }
}

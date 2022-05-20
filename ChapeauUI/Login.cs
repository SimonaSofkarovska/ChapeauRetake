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
       private EmployeeService employeeService = new EmployeeService();
        private Employee employee;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckUser(txtboxUsername.Text, txtboxPassword.Text);
        }

        private void CheckUser(string username, string password)
        {
            try
            {
                employee = employeeService.GetEmployee(username, password);
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                MessageBox.Show($"Incorrect username or password", "Please, sign in again");
                Console.ResetColor();
                return;
            }
           // txtboxUsername.Text = string.Empty;
           // txtboxPassword.Text = string.Empty;

            DisplayScreen(employee);
        }

        private void DisplayScreen(Employee employee)
        {
            if (employee.Role == Role.Manager || employee.Role == Role.Waiter)
            {
                new TableOverview(employee).Show();
            }
            else if (employee.Role == Role.Chef || employee.Role == Role.Barman)
            {
               // new KitchenBar(employee).Show();
            }
        }
    }
}

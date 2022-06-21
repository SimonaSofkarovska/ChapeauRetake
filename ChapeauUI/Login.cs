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
            CheckUser(txtboxUsername.Text, txtboxPassword.Text);
        }
        //verify user
        private void CheckUser(string username, string password)
        {
            Employee employee;
            EmployeeService employeeService = new EmployeeService();

            try
            {
                employee = employeeService.GetEmployee(username, password);
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                MessageBox.Show($"Oops, something went wrong!", e.Message); //think of error handling, username might not exist, database might not be connected
                Console.ResetColor();
                ActiveControl = txtboxPassword;
                txtboxUsername.Text = string.Empty;
                txtboxPassword.Text = string.Empty;
                return;
            }
            

            //CheckRole(txtboxUsername.Text, txtboxPassword.Text);
        }

        //open the right forms according to the employee role
        private void CheckRole(string username, string password)
        {
            Employee employee;
            EmployeeService employeeService = new EmployeeService();
            employee = employeeService.GetEmployee(username, password);

            if (employee != null)
            {
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
                    throw new Exception("Incorrect username or password, please,try again");
                }
            }
        }
    }
}

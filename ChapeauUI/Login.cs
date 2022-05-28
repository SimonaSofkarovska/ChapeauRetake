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
        //private EmployeeService employeeService = new EmployeeService();
        //private Employee employee;
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
            Employee employee = new Employee();
            EmployeeService employeeService = new EmployeeService();

            //read user input
            username = txtboxUsername.Text;
            password = txtboxPassword.Text;

            employee = employeeService.GetEmployee(username, password);

            try
            {
                if (employee != null)
                {
                    //open different forms according to the role of the employee
                    if (employee.Role == Role.Manager)
                    {
                        Form tableOverview = new TableOverview(employee);
                        this.Hide();

                        //open new form same location and size as login form 
                        tableOverview.StartPosition = FormStartPosition.Manual;
                        tableOverview.Location = this.Location;
                        tableOverview.Size = this.Size;

                        tableOverview.ShowDialog();
                    }

                    else if (employee.Role == Role.Waiter || employee.Role == Role.Barman)
                    {
                       // BarKitchen barKitchenView = new BarKitchen(employee);

                        //open new form same location and size as login form
                        //barKitchenView.StartPosition = FormStartPosition.Manual;
                        //barKitchenView.Location = this.Location;
                        //barKitchenView.Size = this.Size;

                        //this.Hide();

                        //barKitchenView.Show();
                    }
                }
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
            //if (employee.Role == 1 || employee.Role == 2)
            //{
            //    new listViewTableOrderOverview(employee).Show();
            //}
            //else if (employee.Role == 3 || employee.Role == 4)
            //{
            //   // new KitchenBar(employee).Show();
            //}
        }
    }
}

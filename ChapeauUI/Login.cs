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

        private void CheckUser(string username, string password)
        {
            Employee employee = new Employee();
            EmployeeService employeeService = new EmployeeService();


            employee = employeeService.GetEmployee(username, password);

            try
            {
                if (employee != null)
                {
                    //open the right forms according to the employee role
                    if (employee.Role == Role.Manager)
                    {
                        Form tableOverview = new TableOverview(employee);
                        this.Hide();

                        //open new form same location and size as the login form 
                        tableOverview.StartPosition = FormStartPosition.Manual;
                        tableOverview.Location = this.Location;
                        tableOverview.Size = this.Size;

                        tableOverview.ShowDialog();
                    }

                    else if (employee.Role == Role.Barman || employee.Role == Role.Chef)
                    {
                         KitchenBar kitchenBarView = new KitchenBar(employee);

                        //open new form same location and size as login form
                        kitchenBarView.StartPosition = FormStartPosition.Manual;
                        kitchenBarView.Location = this.Location;
                        kitchenBarView.Size = this.Size;

                        this.Hide();

                        kitchenBarView.Show(); 
                    }
                    else if (employee.Role == Role.Waiter)
                    {
                        WaiterView waiterView = new WaiterView(employee);

                        //open new form same location and size as login form
                        waiterView.StartPosition = FormStartPosition.Manual;
                        waiterView.Location = this.Location;
                        waiterView.Size = this.Size;

                        this.Hide();

                        waiterView.Show();
                    }

                    else
                    {
                        Console.WriteLine("Oops, something went wrong!");
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
         
        }
       
    }
}

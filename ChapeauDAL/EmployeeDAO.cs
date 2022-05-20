using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class EmployeeDAO :BaseDAO
    {
        public Employee GetEmployee(string username, string password)
        {
            string query = $"SELECT Id, name, role, password FROM [Employee] WHERE name = @name AND password = @password";

            // SqlParameter[] sqlParameters = new SqlParameter[2];
            // sqlParameters[0] = new SqlParameter("name", int.Parse(username));
            // sqlParameters[1] = new SqlParameter("password", password);
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@name", username),
                new SqlParameter("@password", password)
            };

            List<Employee> employees = ReadTableEmployees(ExecuteSelectQuery(query, sqlParameters));
           
            return employees[0];           
        }

        private List<Employee> ReadTableEmployees(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(ReadEmployee(row));
            }

            return employees;
        }
        //get all employees from the database
        public List<Employee> GetAll()
        {
            string query = "SELECT Id, name, role, password FROM [Employee]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableEmployees(ExecuteSelectQuery(query, sqlParameters));
        }
        protected Employee ReadEmployee(DataRow row)
        {
            int id = CheckColumnExist(row, "Id") ? (int)row["Id"] : 0;
            string name = CheckColumnExist(row, "name") ? (string)row["name"] : null;
            Role role = CheckColumnExist(row, "role") ? (Role)row["role"] : 0;
            string password = CheckColumnExist(row, "password") ? (string)row["password"] : null;

            return new Employee(id, name, role, password);
        }
    }
}

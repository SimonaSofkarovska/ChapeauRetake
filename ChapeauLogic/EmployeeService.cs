using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class EmployeeService
    {
        private EmployeeDAO employeeDAO;

        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
        }

        //get specific employee blah
        public Employee GetEmployee(string username, string password)
        {
            Employee employee = employeeDAO.GetEmployee(username, password);
            return employee;
        }
    }
}

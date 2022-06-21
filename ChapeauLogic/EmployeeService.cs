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

        public Employee Login(string givenUsername, string givenPassword)
        {
            return employeeDAO.Login(givenUsername, givenPassword);
        }
    }
}

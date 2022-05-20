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
    
        //get specific employee
        public Employee GetEmployee(string username, string password)
        {
            try
            {
                return employeeDAO.GetEmployee(username, password);
            }
            catch (Exception exp)
            {
                LogDAO.ErrorLog(exp, "EmployeeDAO");
                throw new Exception($"Could not check employee in database");
            }
        }

        //get a list of all employees or throw an exception
        public List<Employee> GetAll()
        {
            try
            {
                return employeeDAO.GetAll();
            }
            catch (Exception exp)
            {
                LogDAO.ErrorLog(exp, "EmployeeDAO");
                throw new Exception($"Could not retrieve employees from database");
            }
        }
    }
}

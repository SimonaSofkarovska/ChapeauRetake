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


        //get a list of all employees or throw an exception
        //public List<Employee> GetAll()
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception exp)
        //    {
               
                
        //    }
        //}

        //get a specific employee or throw an exception
        //public Employee GetspecificEmployee(string username, string password)
        //{
        //    try
        //    {
               
        //    }
        //    catch (Exception exp)
        //    {
                
                
        //    }
        //}
    }
}

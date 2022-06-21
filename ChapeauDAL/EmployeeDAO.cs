using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ChapeauDAL
{
    public class EmployeeDAO : BaseDAO
    {
        public Employee Login(string username, string password)
        {
            string query = "SELECT Id, name, role, password, username FROM Employee WHERE [username] = @username";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@username", username),
            };
            return ReadLogin(ExecuteSelectQuery(query, sqlParameters), password);

        }

        private Employee ReadLogin(DataTable dataTable, string password)
        {
            //read the employee from db
            Employee currentEmployee = new Employee();

            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee()
                {
                    Id = (int)(dr["Id"]),
                    Name = (string)(dr["name"]),
                    Role = (Role)Enum.Parse(typeof(Role), dr["role"].ToString()),
                    Password = dr["password"].ToString(),
                    Username = dr["username"].ToString(),
                };

                //Comparing password in database with the entered password 
                byte[] hashBytes = Convert.FromBase64String(employee.Password);
                // Take the salt out of hashBytes and save it into the salt array
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                // Hash the given password with the salt that was saved in the database, and save the result in the hash array
                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);


                // Compare the hash from the given password with the hash from the database
                bool isCorrect = true;
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        isCorrect = false;
                    }
                }

                if (isCorrect == true)
                {
                    currentEmployee = employee;
                }

            }

            return currentEmployee;
        }



        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.IO;

namespace ChapeauDAL
{
    public  class BaseDAO
    {
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        public BaseDAO()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db_retake1"].ConnectionString);
            adapter = new SqlDataAdapter();
        }

        protected SqlConnection OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                //Print.ErrorLog(e);
                WriteToErrorLog(e.Message);

                throw;
            }
            return connection;
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        //// executes a select queries
        //protected DataTable ExecuteSelectQuery2(string query, params SqlParameter[] sqlParameters)
        //{
        //    SqlCommand command = new SqlCommand();
        //    DataTable dataTable;
        //    DataSet dataSet = new DataSet();

        //    try
        //    {
        //        command.Connection = OpenConnection();
        //        command.CommandText = query;
        //        command.Parameters.AddRange(sqlParameters);
        //        command.ExecuteNonQuery();
        //        adapter.SelectCommand = command;
        //        adapter.Fill(dataSet);
        //        dataTable = dataSet.Tables[0];
        //    }
        //    catch (SqlException exception)
        //    {
        //        // Print.ErrorLog(e);
        //        return null;
        //        throw exception;
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //    return dataTable;
        //}

        ///* For Insert/Update/Delete Queries with transaction */
        //protected void ExecuteEditTranQuery2(string query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        //{
        //    SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
        //    try
        //    {
        //        command.Parameters.AddRange(sqlParameters);
        //        adapter.InsertCommand = command;
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Print.ErrorLog(e);
        //        throw exception;
        //    }
        //}

        ///* For Insert/Update/Delete Queries */
        //protected void ExecuteEditQuery2(string query, SqlParameter[] sqlParameters)
        //{
        //    SqlCommand command = new SqlCommand();

        //    try
        //    {
        //        command.Connection = OpenConnection();
        //        command.CommandText = query;
        //        command.Parameters.AddRange(sqlParameters);
        //        adapter.InsertCommand = command;
        //        command.ExecuteNonQuery();
        //    }
        //    catch (SqlException exception)
        //    {
        //        // Print.ErrorLog(e);
        //        throw exception;
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //}
        //protected bool CheckColumnExist(DataRow dt, string columnName)
        //{
        //    return dt.Table.Columns.Contains(columnName);
        //}

    

        /* For Insert/Update/Delete Queries */
        protected void ExecuteEditQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Print.ErrorLog(e);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        /* For Select Queries */
        protected DataTable ExecuteSelectQuery(string query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
                //Print.ErrorLog(e);
                //return null;
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        protected int ReadCountData(DataTable dataTable)
        {
            int number = 0;

            foreach (DataRow dr in dataTable.Rows)
            {
                number = (int)dr["result"];
            }
            return number;
        }

        protected void WriteToErrorLog(string messege)
        {
            StreamWriter sw = File.AppendText("..\\..\\..\\Error Log.txt");
            sw.WriteLine($"Error occured at: {DateTime.Now}:");
            sw.WriteLine($"{messege}\n");
            sw.Close();
        }
    }
}



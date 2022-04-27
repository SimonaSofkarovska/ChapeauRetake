using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;

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

        // it opens database connection 
        protected SqlConnection OpenConnection()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            return connection;
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        // executes a select queries
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
            catch (SqlException exception)
            {
                // Print.ErrorLog(e);
                return null;
                throw exception;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        /* For Insert/Update/Delete Queries with transaction */
        protected void ExecuteEditTranQuery(string query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        {
            SqlCommand command = new SqlCommand(query, connection, sqlTransaction);
            try
            {
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                //Print.ErrorLog(e);
                throw exception;
            }
        }

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
            catch (SqlException exception)
            {
                // Print.ErrorLog(e);
                throw exception;
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}

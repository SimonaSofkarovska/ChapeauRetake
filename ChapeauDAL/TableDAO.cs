using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauDAL
{
    public class TableDAO:BaseDAO
    {
        //gets tables from database
        public List<Table> GetAll()
        {
            string query = " SELECT tableId, capacity, status FROM [Table] ";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //Read tables and add them to a list of tables
        private List<Table> ReadTables(DataTable table)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow row in table.Rows)
            {
                tables.Add(ReadTable(row));
            }
            return tables;
        }
        //convert DataRow into table object
        protected Table ReadTable(DataRow row)
        {
            int id = CheckColumnExist(row, "tableId") ? (int)row["tableId"] : 0;
            TableStatus tableState = CheckColumnExist(row, "status") ? (TableStatus)row["status"] : 0;

            return new Table(id, tableState);
        }
        protected bool CheckColumnExist(DataRow dt, string columnName)
        {
            return dt.Table.Columns.Contains(columnName);
        }
        //get occupied tables from database
        public List<Table> GetOccupiedTables()
        {
            string query = "SELECT tableId, capacity, [status] FROM [table] Where [status] = 2;";
            SqlParameter[] sqlParameter = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameter));
        }
        //update table status
        public void UpdateTableState(int tableNumber, TableStatus status)
        {
            int tableStatus = (int)status;
            string query = "UPDATE [table] SET [status] = @tableState WHERE tableId = @tableId;";
            SqlParameter[] sqlParameter =
            {
                new SqlParameter("@tableId", tableNumber),
                new SqlParameter("@tableStatus", tableStatus)
            };

            ExecuteEditQuery(query, sqlParameter);
        }

    }
}

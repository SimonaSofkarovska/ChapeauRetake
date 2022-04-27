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
            string query = " SELECT table_id, capacity, [state] FROM [table] ";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //Read tables and add to list of tables
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
            int id = CheckColumnExist(row, "table_id") ? (int)row["table_id"] : 0;
            TableStatus tableState = CheckColumnExist(row, "state") ? (TableStatus)row["state"] : 0;

            return new Table(id, tableState);
        }
        protected bool CheckColumnExist(DataRow dt, string columnName)
        {
            return dt.Table.Columns.Contains(columnName);
        }
    }
}

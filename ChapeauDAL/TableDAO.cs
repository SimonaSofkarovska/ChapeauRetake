using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ChapeauModel;
using System.Collections.Generic;
using ChapeauDAL;

namespace ChapeauDAL
{
    public class TableDAO:BaseDAO
    {
        public List<Table> GetAllTables()
        {
            string query = $"SELECT tableId, capacity, tableNR, status FROM [Table]";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Table> tables = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            return tables;
        }

        public void UpdateStateTableToTrue(int tableNR)
        {
            string query = $"UPDATE [Table] SET status=3 WHERE tableId=@tableNR";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@tableNR", tableNR);

            ExecuteEditQuery(query, sqlParameters);
        }

        public Table GetTableByTableNr(int tableNR)
        {
            // Could you add a breakpoiint on line 42 and 40
            string query = "SELECT tableId, capacity, [status], tableNR FROM [Table] WHERE tableId=@tableNR";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@tableNR", tableNR);

            List<Table> tables = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            if (tables.Count > 0)
            {
                return tables[0];
            } else
            {
                return null;
            }
        }

        // Do you also need to code the order part or is that somebody's else part? Since tableDAO works fine now
        // Yes but the query is now breaking somewhere in the order part
        //order part is someone elses, but i do need to show when there is a running order at the table
        private List<Table> ReadTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table();

                table.TableId = (int)(dr["tableId"]);
                table.Capacity = (int)(dr["capacity"]);
                table.TableNumber = (int)(dr["tableNR"]);
                table.Status = (TableStatus)(dr["status"]);

                tables.Add(table);
            }

            return tables;
        }
    }
}

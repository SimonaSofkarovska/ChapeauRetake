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
            string query = $"SELECT tableID, capacity, tableNumber, isOccupied FROM [Table]";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Table> tables = ReadTables(ExecuteSelectQuery(query, sqlParameters));

            return tables;
        }

        public void UpdateStateTableToTrue(int tableNR)
        {
            string query = $"UPDATE [Table] SET isOccupied=1 WHERE tableID=@tableNR";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("tableNR", tableNR);

            ExecuteEditQuery(query, sqlParameters);
        }

        public Table GetTableByTableNr(int tableNR)
        {
            string query = "SELECT tableID, capacity, tableNumber, isOccupied FROM [Table] WHERE tableNumber=@tableNR;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("tableNR", tableNR);

            List<Table> tables = ReadTables(ExecuteSelectQuery(query, sqlParameters));
            return tables[0];
        }


        private List<Table> ReadTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table();

                table.TableId = (int)(dr["tableID"]);
                table.Capacity = (int)(dr["capacity"]);
                table.TableNumber = (int)(dr["tableNumber"]);
                table.Status = (TableStatus)(int)(dr["status"]);

                tables.Add(table);
            }

            return tables;
        }
        //idk
        public void FoodReady(Table table)
        {
            string query = "UPDATE [TABLE] SET [status] = 2 WHERE table_id = @TableID";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("TableID", (table.TableNumber)),
            };
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}

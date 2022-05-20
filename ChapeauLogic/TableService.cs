using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class TableService
    {
        private TableDAO tableDAO;
        public TableService()
        {
            tableDAO = new TableDAO();
        }
        //public List<Table> GetAllTables()
        //{
        //    List<Table> tables = tableDAO.GetAll();
        //    return tables;
        //}
        //public Table GetTableByTableNR(int tableNr)
        //{
        //    Table table = tableDAO.GetTableByTableNr(tableNr);
        //    return table;

        //}

        //public void UpdateTableState(int tableNR)
        //{
        //    tableDAO.UpdateTableState(tableNR);
        //}

        //get list of all tables from database or throw an exception
        public List<Table> GetAll()
        {
            try
            {
                return tableDAO.GetAll();
            }
            catch (Exception exp)
            {
                LogDAO.ErrorLog(exp, "TableDAO");
                throw new Exception($"Could not access tables from database!");
            }
        }
        //update/change the table's state 
        public void UpdateTableState(int tableNumber, TableStatus tableState)
        {
            try
            {
                tableDAO.UpdateTableState(tableNumber, tableState);
            }
            catch (Exception exp)
            {
                LogDAO.ErrorLog(exp, "TableDAO");
                throw new Exception($"Could not update table state in database");
            }
        }
    }
}

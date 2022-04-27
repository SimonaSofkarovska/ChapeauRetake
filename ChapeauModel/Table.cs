using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int Id { get; set; }
        public TableStatus Status { get; set; }

        public Table(int id, TableStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}

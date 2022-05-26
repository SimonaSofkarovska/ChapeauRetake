using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public enum Role
    {
        Manager = 1,Chef,Waiter,Barman
    }
    public enum OrderStatus
    {
        Waiting, Ready, Serverd
    }
    public enum Payment
    {

    }
    public enum TableStatus
    {
        Free, Reserved, Occupied, Ongoing, FoodReady, FoodServed, Paying
    }
}

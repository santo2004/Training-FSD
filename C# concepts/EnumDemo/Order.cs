using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    enum OrderStatus
    {
        Pending = 1,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    [Flags]
    enum FileAccess
    {
        None = 0,
        Read=1,
        Write=2,
        Execute=4
    }
    internal class Order
    {
        public OrderStatus Status { get; set; }
        public void PrintStatus()
        {
            Console.WriteLine($"Current Status : {Status}");
        }
    }
}

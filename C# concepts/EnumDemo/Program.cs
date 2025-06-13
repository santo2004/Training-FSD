using EnumDemo;
using FileAccess = EnumDemo.FileAccess;

namespace EnumDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order newOrder = new Order();
            newOrder.Status = OrderStatus.Delivered;
            newOrder.PrintStatus();

            EnumDemo.FileAccess access = FileAccess.Read | FileAccess.Write;
            Console.WriteLine(access);

            bool canWrite = (access & FileAccess.Write) == FileAccess.Write;
            Console.WriteLine("Can Write : " + canWrite);
            Console.ReadLine();
        }
    }
}

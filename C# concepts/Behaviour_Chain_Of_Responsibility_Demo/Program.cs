namespace Behaviour_Chain_Of_Responsibility_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SupportHandler level1 = new SupportHandler();
            SupportHandler level2 = new SupportHandler();
            SupportHandler manager = new SupportHandler();

            level1.SetNext(level2);
            level2.SetNext(manager);

            level1.HandleRequest("password rest");
            level1.HandleRequest("software issue");
            level1.HandleRequest("admin request");

            Console.ReadLine();
        }
    }
}

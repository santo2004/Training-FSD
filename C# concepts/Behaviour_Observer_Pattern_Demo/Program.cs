namespace Behaviour_Observer_Pattern_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            MobileApp mobile = new MobileApp();
            WebApp web = new WebApp();

            stock.RegisterObserver(mobile);
            stock.RegisterObserver(web);

            stock.SetPrice(48000);
            stock.SetPrice(39000);

            stock.RemoveObserver(web);

            stock.SetPrice(34000);
            Console.ReadLine();
        }
    }
}

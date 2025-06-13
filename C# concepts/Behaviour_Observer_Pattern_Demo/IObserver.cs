using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behaviour_Observer_Pattern_Demo
{
    public interface IObserver
    {
        void Update(decimal price);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Stock : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private decimal price;

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(price);
            }
        }

        public void RegisterObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void SetPrice(decimal newPrice)
        {
            Console.WriteLine($"\n new price of the stock {newPrice}");
            price = newPrice;
            NotifyObservers();
        }
    }

    public class WebApp : IObserver
    {
        public void Update (decimal price)
        {
            Console.WriteLine($"web app notification new price of the stock is {price:C}");
        }
    }

    public class MobileApp : IObserver
    {
        public void Update (decimal price)
        {
            Console.WriteLine($"mobile app nitification new price of the stock is {price:C}");
        }
    }

}

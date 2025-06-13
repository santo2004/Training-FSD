namespace GenericsDemo
{
    // Generic Method Class
    class GenericMethod
    {
        // Generic Swap Method
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    // Generic Class
    class GenericClass<T1, T2>
    {
        T1 a;
        T2 b;

        public GenericClass(T1 a, T2 b)
        {
            this.a = a;
            this.b = b;
        }

        public void Display()
        {
            Console.WriteLine($"The first value: {a}");
            Console.WriteLine($"The second value: {b}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrating Generic Method
            int x = 10, y = 20;
            Console.WriteLine("Before Swap:");
            Console.WriteLine($"x = {x}, y = {y}");

            GenericMethod.Swap(ref x, ref y);

            Console.WriteLine("After Swap:");
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine();

            // Demonstrating Generic Class
            GenericClass<int, string> iobj = new GenericClass<int, string>(10, "Hi");
            GenericClass<string, char> sobj = new GenericClass<string, char>("Geetha", 'n');

            iobj.Display();
            Console.WriteLine();
            sobj.Display();

            Console.ReadKey();

        }
    }
}

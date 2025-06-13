using CalculatorLibrary;
using CalculatorLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        InvoiceCalculator calculator = new InvoiceCalculator();
        Console.WriteLine("Enter the base amount:");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter the tax rate (in %):");
        decimal tax = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter the discount rate (in %):");
        decimal discount = Convert.ToDecimal(Console.ReadLine());

        string invoiceNumber = calculator.GenerateInvoiceNumber();
        string summary = calculator.GetInvoiceSummary(amount, tax, discount);

        Console.WriteLine($"Invoice Number: {invoiceNumber}");
        Console.WriteLine("Invoice Summary:");
        Console.WriteLine(summary);
        Console.ReadLine();
    }
}
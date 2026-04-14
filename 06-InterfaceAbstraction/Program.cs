using _06_InterfaceAbstraction.İnterface;
using _06_InterfaceAbstraction.Models;

namespace _06_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculation calculation = new Calculation();
            Console.WriteLine("X daxil et: ");
            calculation.X=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Y daxil et: ");
            calculation.Y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Emeliyyat (+,-,*,/): ");
            calculation.Operation = Console.ReadLine();
            calculation.Calculate();    
        }
    }
}

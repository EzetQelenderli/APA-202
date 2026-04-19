using _07_NullableEnumStruct.Enums;
using _07_NullableEnumStruct.Models;
using System.Drawing;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrinkOrder drinkOrder1 = new(101, "Ali", Enums.DrinkType.Coffee, Enums.DrinkSize.Medium, Enums.OrderStatus.New, 8);
            drinkOrder1.Price = drinkOrder1.CalculatePrice();
            drinkOrder1.DisplayOrder();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            DrinkOrder drinkOrder2 = new(102, "Leyla", Enums.DrinkType.Tea, Enums.DrinkSize.Large, Enums.OrderStatus.Ready, 6);
            drinkOrder2.Price = drinkOrder2.CalculatePrice();
            drinkOrder2.DisplayOrder();
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            DrinkOrder drinkOrder3 = new(103, "Vuqar", Enums.DrinkType.Juice, Enums.DrinkSize.Small, Enums.OrderStatus.Preparing, 6);
            drinkOrder3.Price = drinkOrder3.CalculatePrice();
            drinkOrder3.DisplayOrder();
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (OrderStatus order in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine((int)order + "" + order);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (DrinkType type in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine((int)type + "" + type);
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (DrinkSize size in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine((int)size + "" + size);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            {
                DrinkType type = DrinkType.Coffee;
                Console.WriteLine('"' + DrinkType.Coffee.ToString() + '"');

                DrinkSize size = DrinkSize.Large;
                Console.WriteLine('"' + DrinkSize.Large.ToString() + '"');
            }
            string InputType = "Tea";
            DrinkType ParsedType = (DrinkType)Enum.Parse(typeof(DrinkType),InputType);
            Console.WriteLine(ParsedType);
            string InputSize = "Medium";
            DrinkSize ParsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize),InputSize);
            Console.WriteLine(ParsedSize);

            Console.WriteLine("----------------------------------------------------------------------------------------");
            double price1 = 6;
            double price2 = 6.5;
            double price3 = 5.5;
            double TotalOrder = 3;
            double TotalPrice = price1 + price2 + price3;
            Console.WriteLine("Umumi sifaris:"+TotalOrder);
            Console.WriteLine("Umumi qiymet:"+TotalPrice);
            Console.WriteLine("1-ci sifarisin qiymeti:"+price1);
            Console.WriteLine("2-ci sifarisin qiymeti:"+price2);
            Console.WriteLine("3-ci sifarisin qiymeti:"+price3);
            
        }
    }
}

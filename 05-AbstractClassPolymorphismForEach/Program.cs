
using System.Net.WebSockets;

internal class Program
{
    static void Main(string[] args)
    {
        Car Car = new Car("Mercedes", "E200", 2023, "50-DS-060", 4, 500, true, 220);
        Car Car1 = new Car("BMW", "320i", 2020, "50-DS-060", 4, 480, true, 235);
        Car Car2 = new Car("Toyota ", "Camry", 2021, "50-DS-060", 4, 524, true, 210);
        Car.ShowCarInfo();
        Console.WriteLine($"fuelcost:(500km):{Car.CalculateFuelCost(500)}");
        Car1.ShowCarInfo();
        Console.WriteLine($"fuelcost:(500km):{Car1.CalculateFuelCost(500)}");
        Car2.ShowCarInfo();
        Console.WriteLine($"fuelcost:(500km):{Car2.CalculateFuelCost(500)}");
        double costcar = Car.CalculateFuelCost(500);
        double costcar1 = Car1.CalculateFuelCost(500);
        double costcar2 = Car2.CalculateFuelCost(500);

        Console.WriteLine("---------------------------------------------------------------");

        Motorcycle Motorcycle = new Motorcycle("Yamaha", "R1", 2023, "01-AB-90", 998, false, 299, "sport");
        Motorcycle Motorcycle2 = new Motorcycle("Harley", "Davidson", 2022, "01-AB-90", 1868, true, 160, "cruiser");
        Motorcycle.ShowMotorcycleInfo();

        Console.WriteLine($"fuelcost:(300km):{Motorcycle.CalculateFuelCost(300)}");
        Motorcycle2.ShowMotorcycleInfo();
        Console.WriteLine($"fuelcost:(300km):{Motorcycle2.CalculateFuelCost(300)}");
        double costmoto = Motorcycle.CalculateFuelCost(300);
        double costmoto2 = Motorcycle.CalculateFuelCost(300);

        Console.WriteLine("---------------------------------------------------------------");



        Truck Truck = new Truck("MAN", "TGX", 2020, "12-AB-21", 18, 3, 12, 120);
        Truck Truck1 = new Truck("Volvo", "FH16", 2021, "12-AB-21", 25, 4, 18, 110);
        Truck.ShowTruckInfo();
        Console.WriteLine($"fuelcost:(800km):{Truck.CalculateFuelCost(800)}");
        Truck1.ShowTruckInfo();
        Console.WriteLine($"fuelcost:(800km):{Truck1.CalculateFuelCost(800)}");
        double costtruck = Truck.CalculateFuelCost(800);
        double costtruck1 = Truck1.CalculateFuelCost(800);
        Truck.LoadCargo(5);
       
        


        Console.WriteLine("---------------------------------------------------------------");
    }


}



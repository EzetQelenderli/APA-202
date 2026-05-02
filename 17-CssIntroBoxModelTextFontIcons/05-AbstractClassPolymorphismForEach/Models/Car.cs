using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


    internal class Car : Vehicle
{
    public int DoorsCount { get; set; }
    public int TrunkCapacity { get; set; }
    public bool IsAutomatic { get; set; }
    public int MaxSpeed { get; set; }
    public Car(string brand, string model, int year, string plateNumber, int doorsCount, int trunkCapacity, bool isAutomatic, int maxSpeed) : base(brand, model, year, plateNumber)
    {
        DoorsCount = doorsCount;
        TrunkCapacity = trunkCapacity;
        IsAutomatic = isAutomatic;
        MaxSpeed = maxSpeed;

    }
    public void ShowCarInfo()
    {
        Console.WriteLine($"brand:{Brand},model:{Model},year:{Year},platenumber:{PlateNumber},doorscount:{DoorsCount},trunkCapacity:{TrunkCapacity}L,isAutomatc:{IsAutomatic},maxSpeed:{MaxSpeed}km/s");

    }
    public double CalculateFuelCost(double distance)
    {
        return (distance / 100) * 8 * 1.50;
    }
}
   

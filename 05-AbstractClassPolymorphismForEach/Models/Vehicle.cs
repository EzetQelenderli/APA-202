using System;
using System.Collections.Generic;
using System.Text;

internal class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string PlateNumber { get; set; }
    public double FuelLevel { get; set; }
    public Vehicle(string brand, string model, int year, string plateNumber)
    {
        Brand = brand;
        Model = model;
        Year = year;
        PlateNumber = plateNumber;
        FuelLevel = 100;

    }
    public void ShowInfo()
    {
        Console.WriteLine($"Brand:{Brand},Model:{Model},Year:{Year},PlateNumber:{PlateNumber},FuelLevel:{FuelLevel}");
    }
}



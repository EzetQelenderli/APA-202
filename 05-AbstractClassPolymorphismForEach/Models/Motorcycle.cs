using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


    internal class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }
        public Motorcycle(string brand, string model, int year, string plateNumber, int engineCapacity, bool hasSideCar, int maxSpeed, string type) : base(brand, model, year, plateNumber)
        {
            this.EngineCapacity = engineCapacity;
            this.HasSidecar = hasSideCar;
            this.MaxSpeed = maxSpeed;
            this.Type = type;

        }
        public void ShowMotorcycleInfo()
        {
            Console.WriteLine($"brand:{Brand},model:{Model},year:{Year},platenumber:{PlateNumber},engineCapacity:{EngineCapacity}cc,hasSideCar:{HasSidecar},maxSpeed:{MaxSpeed}km/s,type:{Type}");
        }
        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }




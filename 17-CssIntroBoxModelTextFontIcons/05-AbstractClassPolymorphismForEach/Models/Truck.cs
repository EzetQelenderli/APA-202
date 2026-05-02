using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


        internal class Truck : Vehicle
        {
            public double CargoCapacity { get; set; }
            public int AxleCount { get; set; }
            public double CurrentLoad { get; set; }
            public int MaxSpeed { get; set; }
            public double Load { get; set; }
            public double FuelConsumption { get; set; }
            public Truck(string brand, string model, int year, string plateNumber, double cargoCapacity, int axleCount, double currentLoad, int maxSpeed) : base(brand, model, year, plateNumber)
            {
                this.CargoCapacity = cargoCapacity;
                this.AxleCount = axleCount;
                this.CurrentLoad = currentLoad;
                this.MaxSpeed = maxSpeed;

            }
            public void ShowTruckInfo()
            {
                Console.WriteLine($"brand:{Brand},model:{Model},year:{Year},platenumber:{PlateNumber},cargoCapacity:{CargoCapacity}ton,axleCount:{AxleCount},currentLoad:{CurrentLoad}ton,maxSpeed:{MaxSpeed}km/s");
            }

            public double currentLoad { get; set; }
            public void LoadCargo(double weight)
            {
                if (currentLoad + weight <= CargoCapacity)
                {
                    currentLoad += weight;
                    Console.WriteLine("yuk qoyuldu");
                }
                else
                {
                    Console.WriteLine("tutum heddinden coxdur!!");
                }
            }
            public double CalculateFuelCost(double distance)
            {
                return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
            }
            public void AddLoad(double amount)
            {
                Load += amount;
            }
            public double CalculateFuel(double distance)
            {
                return (FuelConsumption / 100) + distance;
            }
            public void ShowTrucnkInfo()
            {
                Console.WriteLine($"yuk:{Load}ton,Yanacag serfi:{FuelConsumption}");
            }
        }
    


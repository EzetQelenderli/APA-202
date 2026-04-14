using _06_InterfaceAbstraction.İnterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace _06_InterfaceAbstraction.Models
{
    internal class Calculation : ICalculation
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Operation { get; set; } = "";

        public void Calculate()
        {
        

            if (Operation == "+")
                Console.WriteLine(X + Y);
            else if (Operation == "-")
                Console.WriteLine(X - Y);
            else if (Operation == "*")
                Console.WriteLine(X * Y);
            else if (Operation == "/")
                if (Y != 0)
                    Console.WriteLine(X / Y);
                else
                {
                    Console.WriteLine("o-a bolmek olmaz !!");
                }
            else
            {
                Console.WriteLine("Yalnis emeliyyat!!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal abstract class Animal
    {
        public int AvgLife { get; set; }
        public string Gender { get; set; }
        public virtual void Eat() 
        {
            Console.WriteLine("Qidalanir");
        }

    }
}

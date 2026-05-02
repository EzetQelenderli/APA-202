using System;
using System.Collections.Generic;
using System.Text;

namespace _06_InterfaceAbstraction.İnterface
{
    internal interface ICalculation
    {
        double X { get; set; }
        double Y { get; set; }
        string Operation { get; set; }
        void Calculate();
    }
}

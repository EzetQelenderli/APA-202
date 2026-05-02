using System;
using System.Collections.Generic;
using System.Text;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    internal class Dollar
    {
        public decimal USD { get; set; }
        public Dollar(decimal usd)
        {
            USD= usd;
        }
        public static implicit operator Dollar(Manat manat)
        {
            return new Dollar(manat.AZN/1.7m);
        }
    }
}

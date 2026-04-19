using System;
using System.Collections.Generic;
using System.Text;

namespace AccesModifires.Models
{
    public class Car
    {
        private int _horsePower;
        public int HorsePower
        {
            get
            {
                return _horsePower;
            }

            set
            {
                _horsePower = value;
            }

        }
    }
}

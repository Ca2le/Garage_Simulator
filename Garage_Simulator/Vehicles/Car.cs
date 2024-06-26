﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    public class Car : Vehicle
    {
        public Car(bool withRoof, string regNr, int price, int size, string color) : base(regNr, price, size, color)
        { 
            WithRoof = withRoof;
        }

        public bool WithRoof { get; set; }
        public override ConsoleColor ThemeColor {
            get {

                return ConsoleColor.Green;

            }
        }
        
    }
}

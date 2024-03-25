using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator.Vehicles
{
    internal class Car : Vehicle
    {
        public Car(string model, double price, string regPlate, ) {
            Model = model;
            Price = price;
            RegistrationPlate = regPlate;
        }
        public override ConsoleColor Color {
            get {
                return ConsoleColor.Green;
            }
        }
        public override int Size
        {
            get
            {
                return 2;
            }
        }
    }
}

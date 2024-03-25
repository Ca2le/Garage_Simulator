using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal abstract class Vehicle
    {
        public string RegistrationPlate { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public abstract ConsoleColor Color { get; }
        public abstract int Size { get; }
    }
}

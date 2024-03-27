using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    public abstract class Vehicle
    {
        public Vehicle(string regNr, int price, int size, string color)
        {
            RegistrationPlate = regNr;
            Price = price;
            Size = size;
            Color = color;
           
        }
        public string RegistrationPlate { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public abstract ConsoleColor ThemeColor { get; }
        public int Size { get; }

        // Implementing IEnumerable<T> members
      
    }
}

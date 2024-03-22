using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class ColorBook
    {
       public Dictionary<string, ConsoleColor> color = new Dictionary<string, ConsoleColor>(StringComparer.OrdinalIgnoreCase)
        {
            { "blue", ConsoleColor.Blue },
            { "green", ConsoleColor.Green },
            { "yellow", ConsoleColor.Yellow },
            { "red", ConsoleColor.Red }
        };

        public ConsoleColor GetColor(string color)
        {
            return this.color[color];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal static class  ColorBook
    {
        public static ConsoleColor GetColor(string colorName)
        {
            switch (colorName.ToLower())
            {
                case "black": return ConsoleColor.Black;
                case "darkblue": return ConsoleColor.DarkBlue;
                case "darkgreen": return ConsoleColor.DarkGreen;
                case "darkcyan": return ConsoleColor.DarkCyan;
                case "darkred": return ConsoleColor.DarkRed;
                case "darkmagenta": return ConsoleColor.DarkMagenta;
                case "darkyellow": return ConsoleColor.DarkYellow;
                case "gray": return ConsoleColor.Gray;
                case "darkgray": return ConsoleColor.DarkGray;
                case "blue": return ConsoleColor.Blue;
                case "green": return ConsoleColor.Green;
                case "cyan": return ConsoleColor.Cyan;
                case "red": return ConsoleColor.Red;
                case "magenta": return ConsoleColor.Magenta;
                case "yellow": return ConsoleColor.Yellow;
                case "white": return ConsoleColor.White;
                default:
                    // Default color
                    return ConsoleColor.White;
            }
        }
    }
}

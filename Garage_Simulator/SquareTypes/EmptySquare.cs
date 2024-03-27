using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class EmptySquare : Square
    {
        public override ConsoleColor Color()
        {
            return ConsoleColor.Green;
        }
        public override string Texture()
        {
            return "  ";
        }
        public override bool Active()
        {
            return false;
        }
    }
}

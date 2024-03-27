using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class BusySquare : Square
    {
        public override ConsoleColor Color()
        {
            return ConsoleColor.Red;
        }
        public override string Texture()
        {
            return "XX";
        }
        public override bool Active()
        {
            return false;
        }
    }
}

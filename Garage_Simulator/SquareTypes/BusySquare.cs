using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class BusySquare : Square
    {
        public override string Color()
        {
            return "red";
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

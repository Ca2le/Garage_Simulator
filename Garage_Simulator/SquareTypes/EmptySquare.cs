using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class EmptySquare : Square
    {
        public override string Color()
        {
            return "red";
        }
        public override char Texture()
        {
            return ' ';
        }
        public override bool Active()
        {
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Garage_Simulator
{
    public class AirPlane : Vehicle
    {
        public AirPlane(int passangers , string regNr, int price, int size, string color) : base(regNr, price, size, color)
        {
           Passangers = passangers;

        }

        public int Passangers { get; set; }
        public override ConsoleColor ThemeColor
        {
            get
            {
                return ConsoleColor.Gray;
            }
        }

    }
}

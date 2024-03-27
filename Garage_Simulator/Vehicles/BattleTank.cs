using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Garage_Simulator
{
    public class BattleTank : Vehicle
    {
        public BattleTank(int cannonBalls, string regNr, int price, int size, string color) : base(regNr, price, size, color)
        {
            CannonBalls = cannonBalls;
        }

        public int CannonBalls { get; set; }
        public override ConsoleColor ThemeColor
        {
            get
            {
                return ConsoleColor.Green;
            }
        }

    }
}

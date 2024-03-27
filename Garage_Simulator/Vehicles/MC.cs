using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    public class MC : Vehicle
    {
        public MC(string cubicCentimeter, string regNr, int price, int size, string color) : base(regNr, price, size, color)
        {
            CubicCentimeter = cubicCentimeter;
        }


        public string CubicCentimeter { get; set; }

        public override ConsoleColor ThemeColor {
            get {
                return ConsoleColor.Green;
            }
        }
       


    }
}

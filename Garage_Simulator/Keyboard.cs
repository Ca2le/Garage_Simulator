using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    internal class Keyboard
    {
        public bool IsActive { get; set; }
        public ConsoleKeyInfo LastKeyPressed { get; set; }

        public void On ()
        {
            IsActive = true;
            while (IsActive) {
                ConsoleKeyInfo key = Console.ReadKey();

                Console.Clear();
                switch(key.KeyChar)
                {
                    case 'w' : {
                            break;
                        }
                    case 'a':
                        {
                            break;
                        }
                    case 's':
                        {
                            break;
                        }
                    case 'd':
                        {
                            break;
                        }
                    case '0': 
                        {
                            IsActive = false;
                            break;
                        }
                }
                if(key.KeyChar == '0') IsActive = false;
            }
        }
        public void Off()
        {
            IsActive = false;
        }
    }
}

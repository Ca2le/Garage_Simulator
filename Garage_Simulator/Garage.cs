using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Simulator
{
    public class Garage<T>
    {
        private T[] _space;

        public Garage()
        {
            int size = GarageConfig.Get.GridSize;
            _space = new T[size];
        }
        public Garage(int size)
        {
            _space = new T[size];
        }
        public T[] Space
        {
            get { return _space; }
            set { _space = value; }
        }

       
    }
}

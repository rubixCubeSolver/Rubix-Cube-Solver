using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubix_Cube_Solver
{
    class cubit
    {
        private int _color1;
        private int _color2;
        private int _color3;

        public cubit(int color1, int color2)
        {
            _color1 = color1;
            _color2 = color2;
        }

        public cubit(int color1, int color2, int color3)
        {
            _color1 = color1;
            _color2 = color2;
            _color3 = color3;
        }
    }
}

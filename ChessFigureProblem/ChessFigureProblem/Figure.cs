using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessFigureProblem
{
    class Figure
    {
        private char look;

        public char GetLook
        {
            get
            {
                char _look = look;
                return _look;
            }
        }
        public char SetLook
        {
            set
            {
                look = value;
            }
        }

        public Figure(char _look)
        {
            look = _look;
        }
    }
}

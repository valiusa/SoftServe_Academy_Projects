using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessFigureProblem
{
    class Point
    {
        private byte pX;
        private byte pY;

        public Point(byte _pX = 0, byte _pY = 0)
        {
            pX = _pX;
            pY = _pY;
        }

        public byte GetX
        {
            get
            {
                byte pointX = pX;
                return pointX;
            }
        }
        public byte SetX
        {
            set
            {
                pX = value;
            }
        }

        public byte GetY
        {
            get
            {
                byte pointY = pY;
                return pointY;
            }
        }
        public byte SetY
        {
            set
            {
                pY = value;
            }
        }
    }
}

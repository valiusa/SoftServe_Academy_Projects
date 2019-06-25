using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessFigureProblem
{
    interface IFigure
    {
        char GetLook { get; }
        char SetLook { set; }
    }

    class Figure : IFigure
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
            switch (_look)
            {
                case 'p':
                    look = '\u2659';
                    break;
                case 'k':
                    look = '\u2658';
                    break;
                case 'b':
                    look = '\u2657';
                    break;
                case 'r':
                    look = '\u2656';
                    break;
                case 'Q':
                    look = '\u2655';
                    break;
                case 'K':
                    look = '\u2654';
                    break;
                default:
                    break;
            }
        }
    }
}

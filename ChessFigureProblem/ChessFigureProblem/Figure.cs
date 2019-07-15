namespace ChessFigureProblem
{
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
                    look = '\u2659'; // Pawn
                    break;
                case 'k':
                    look = '\u2658'; // Knight
                    break;
                case 'b':
                    look = '\u2657'; // Bishop
                    break;
                case 'r':
                    look = '\u2656'; // Rook
                    break;
                case 'Q':
                    look = '\u2655'; // Queen
                    break;
                case 'K':
                    look = '\u2654'; // King
                    break;
                default:
                    look = _look; // User
                    break;
            }
        }
    }
}

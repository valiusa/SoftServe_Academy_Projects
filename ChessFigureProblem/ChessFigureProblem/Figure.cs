using System;

namespace ChessFigureProblem
{
    class ChessFigure : IFigure
    {
        protected char look;
        protected const char fight = 'x';

        public char GetFight
        {
            get
            {
                char _fight = fight;
                return _fight;
            }
        }

        public char GetLook
        {
            get
            {
                return look;
            }
        }
        public char SetLook
        {
            set
            {
                look = value;
            }
        }

        public ChessFigure(char _look)
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

        public void SetPawnFightPos(ref byte posX, ref byte posY, ref byte count, char[,] board, byte size)
        {
            Random rnd = new Random();

            // If the figure position is greater or equals to half of the size it fight positions are set upwards else they are put downwards
            if (posX >= size / 2)
            {
                SetOnBottomSide(posX, posY, count, look, size, board, rnd);                
            }
            else
            {
                SetOnTopSide(posX, posY, count, look, size, board, rnd);                
            }
        }

        public void SetKnightFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            SetUpperFightPos(posX, posY, board, size);
            SetLowerFightPos(posX, posY, board, size);            
        }
        
        public void SetBishopFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Left-Diagonal-Fight-Pos And Right-Diagonal-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                SetLeftDiagonal(posX, posY, board, size, i);
                SetRightDiagonal(posX, posY, board, size, i);                
            }
        }
        
        public void SetRookFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Horizontal-Fight-Pos And Vertical-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                SetHorizontal(posX, posY, board, size, i);
                SetVertical(posX, posY, board, size, i);                
            }
        }

        public void SetQueenFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Left-Diagonal-Fight-Pos And Right-Diagonal-Fight-Pos | Horizontal-Fight-Pos And Vertical-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                SetLeftDiagonal(posX, posY, board, size, i);
                SetRightDiagonal(posX, posY, board, size, i);
                SetHorizontal(posX, posY, board, size, i);
                SetVertical(posX, posY, board, size, i);
            }
        }

        public void SetKingFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            const byte i = 1;

            SetLeftDiagonal(posX, posY, board, size, i);
            SetRightDiagonal(posX, posY, board, size, i);
            SetHorizontal(posX, posY, board, size, i);
            SetVertical(posX, posY, board, size, i);
        }

        private void SetRightDiagonal(byte posX, byte posY, char[,] board, byte size, int counter)
        {
            // Right-Upper
            if (posX - counter >= 0 && posY + counter < size)
            {
                board[posX - counter, posY + counter] = fight;
            }
            // Left-Down
            if (posX + counter < size && posY - counter >= 0)
            {
                board[posX + counter, posY - counter] = fight;
            }
        }

        private void SetLeftDiagonal(byte posX, byte posY, char[,] board, byte size, int counter)
        {
            // Left-Upper
            if (posX - counter >= 0 && posY - counter >= 0)
            {
                board[posX - counter, posY - counter] = fight;
            }
            // Right-Down
            if (posX + counter < size && posY + counter < size)
            {
                board[posX + counter, posY + counter] = fight;
            }
        }

        private void SetLowerFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Down-Left-Upper-Fight-Pos
            if (posX + 1 < size && posY - 2 >= 0)
                board[posX + 1, posY - 2] = fight;
            // Down-Left-Down-Fight-Pos
            if (posX + 2 < size && posY - 1 >= 0)
                board[posX + 2, posY - 1] = fight;
            // Down-Right-Upper-Fight-Pos
            if (posX + 1 < size && posY + 2 < size)
                board[posX + 1, posY + 2] = fight;
            // Down-Right-Down-Fight-Pos
            if (posX + 2 < size && posY + 1 < size)
                board[posX + 2, posY + 1] = fight;
        }

        private void SetUpperFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Upper-Left-Upper-Fight-Pos
            if (posX - 2 >= 0 && posY - 1 >= 0)
                board[posX - 2, posY - 1] = fight;
            // Upper-Left-Down-Fight-Pos
            if (posX - 1 >= 0 && posY - 2 >= 0)
                board[posX - 1, posY - 2] = fight;
            // Upper-Right-Upper-Fight-Pos
            if (posX - 2 >= 0 && posY + 1 < size)
                board[posX - 2, posY + 1] = fight;
            // Upper-Right-Down-Fight-Pos
            if (posX - 1 >= 0 && posY + 2 < size)
                board[posX - 1, posY + 2] = fight;
        }

        private void SetHorizontal(byte posX, byte posY, char[,] board, byte size, int counter)
        {
            // LeftSide-Horizontal
            if (posY - counter >= 0)
            {
                board[posX, posY - counter] = fight;
            }
            // RightSide-Horizontal
            if (posY + counter < size)
            {
                board[posX, posY + counter] = fight;
            }
        }

        private void SetVertical(byte posX, byte posY, char[,] board, byte size, int counter)
        {
            // Upper-Vertical
            if (posX - counter >= 0)
            {
                board[posX - counter, posY] = fight;
            }
            // Down-Vertical
            if (posX + counter < size)
            {
                board[posX + counter, posY] = fight;
            }
        }

        private void SetOnTopSide(byte posX, byte posY, byte count, char look, byte size, char[,] board, Random rnd)
        {
            if (posX + 1 < size && posY - 1 >= 0)
            {
                if (board[posX + 1, posY - 1] != look)
                {
                    board[posX + 1, posY - 1] = fight; // Down-Left-Fight-Pos
                }
                else
                {
                    count--;
                    if (posX + 1 < size && posY + 1 < size)
                    {
                        board[posX + 1, posY + 1] = '\0';
                    }

                    posX = (byte)rnd.Next(0, size);
                    posY = (byte)rnd.Next(0, size);

                    SetPawnFightPos(ref posX, ref posY, ref count, board, size);
                }
            }
            if (posX + 1 < size && posY + 1 < size)
            {
                if (board[posX + 1, posY + 1] != look)
                {
                    board[posX + 1, posY + 1] = fight; // Down-Right-Fight-Pos
                }
                else
                {
                    count--;
                    if (posX + 1 < size && posY - 1 >= 0)
                    {
                        board[posX + 1, posY - 1] = '\0';
                    }

                    posX = (byte)rnd.Next(0, size);
                    posY = (byte)rnd.Next(0, size);

                    SetPawnFightPos(ref posX, ref posY, ref count, board, size);
                }
            }
        }

        private void SetOnBottomSide(byte posX, byte posY, byte count, char look, byte size, char[,] board, Random rnd)
        {
            if (posX - 1 >= 0 && posY - 1 >= 0)
            {
                if (board[posX - 1, posY - 1] != look)
                {
                    board[posX - 1, posY - 1] = fight; // Upper-Left-Fight-Pos
                }
                else
                {
                    count--;
                    if (posX - 1 >= 0 && posY + 1 < size)
                    {
                        board[posX - 1, posY + 1] = '\0';
                    }

                    posX = (byte)rnd.Next(0, size);
                    posY = (byte)rnd.Next(0, size);

                    SetPawnFightPos(ref posX, ref posY, ref count, board, size);
                }
            }
            if (posX - 1 >= 0 && posY + 1 < size)
            {
                if (board[posX - 1, posY + 1] != look)
                {
                    board[posX - 1, posY + 1] = fight; // Upper-Right-Fight-Pos
                }
                else
                {
                    count--;
                    if (posX - 1 >= 0 && posY - 1 >= 0)
                    {
                        board[posX - 1, posY - 1] = '\0';
                    }

                    posX = (byte)rnd.Next(0, size);
                    posY = (byte)rnd.Next(0, size);

                    SetPawnFightPos(ref posX, ref posY, ref count, board, size);
                }
            }
        }
    }
}

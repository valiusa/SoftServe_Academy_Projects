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
            else
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
        }

        public void SetKnightFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Upper-Left-Upper-Fight-Pos
            if (posX - 2 >= 0 && posY - 1 >= 0)
            {
                board[posX - 2, posY - 1] = fight;
            }
            // Up-Left-Down-Fight-Pos
            if (posX - 1 >= 0 && posY - 2 >= 0)
            {
                board[posX - 1, posY - 2] = fight;
            }
            // Up-Right-Upper-Fight-Pos
            if (posX - 2 >= 0 && posY + 1 < size)
            {
                board[posX - 2, posY + 1] = fight;
            }
            // Up-Right-Down-Fight-Pos
            if (posX - 1 >= 0 && posY + 2 < size)
            {
                board[posX - 1, posY + 2] = fight;
            }
            //-------------------------------------
            // Down-Left-Upper-Fight-Pos
            if (posX + 1 < size && posY - 2 >= 0)
            {
                board[posX + 1, posY - 2] = fight;
            }
            // Down-Left-Down-Fight-Pos
            if (posX + 2 < size && posY - 1 >= 0)
            {
                board[posX + 2, posY - 1] = fight;
            }
            // Down-Right-Upper-Fight-Pos
            if (posX + 1 < size && posY + 2 < size)
            {
                board[posX + 1, posY + 2] = fight;
            }
            // Down-Right-Down-Fight-Pos
            if (posX + 2 < size && posY + 1 < size)
            {
                board[posX + 2, posY + 1] = fight;
            }
        }

        public void SetBishopFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Left-Diagonal-Fight-Pos And Right-Diagonal-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                // Left-Upper
                if (posX - i >= 0 && posY - i >= 0)
                {
                    board[posX - i, posY - i] = fight;
                }
                // Right-Down
                if (posX + i < size && posY + i < size)
                {
                    board[posX + i, posY + i] = fight;
                }
                //-------------------------------------
                // Right-Upper
                if (posX - i >= 0 && posY + i < size)
                {
                    board[posX - i, posY + i] = fight;
                }
                // Left-Down
                if (posX + i < size && posY - i >= 0)
                {
                    board[posX + i, posY - i] = fight;
                }
            }
        }

        public void SetRookFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Horizontal-Fight-Pos And Vertical-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                // LeftSide-Horizontal
                if (posY - i >= 0)
                {
                    board[posX, posY - i] = fight;
                }
                // RightSide-Horizontal
                if (posY + i < size)
                {
                    board[posX, posY + i] = fight;
                }
                //-------------------------------------
                // Upper-Vertical
                if (posX - i >= 0)
                {
                    board[posX - i, posY] = fight;
                }
                // Down-Vertical
                if (posX + i < size)
                {
                    board[posX + i, posY] = fight;
                }
            }
        }

        public void SetQueenFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Left-Diagonal-Fight-Pos And Right-Diagonal-Fight-Pos | Horizontal-Fight-Pos And Vertical-Fight-Pos
            for (int i = 1; i <= size; i++)
            {
                // Left-Upper-Diagonal
                if (posX - i >= 0 && posY - i >= 0)
                {
                    board[posX - i, posY - i] = fight;
                }
                // Right-Down-Diagonal
                if (posX + i < size && posY + i < size)
                {
                    board[posX + i, posY + i] = fight;
                }
                // Right-Upper-Diagonal
                if (posX - i >= 0 && posY + i < size)
                {
                    board[posX - i, posY + i] = fight;
                }
                // Left-Down-Diagonal
                if (posX + i < size && posY - i >= 0)
                {
                    board[posX + i, posY - i] = fight;
                }
                //-------------------------------------
                // LeftSide-Horizontal
                if (posY - i >= 0)
                {
                    board[posX, posY - i] = fight;
                }
                // RightSide-Horizontal
                if (posY + i < size)
                {
                    board[posX, posY + i] = fight;
                }
                //-------------------------------------
                // Upper-Vertical
                if (posX - i >= 0)
                {
                    board[posX - i, posY] = fight;
                }
                // Down-Vertical
                if (posX + i < size)
                {
                    board[posX + i, posY] = fight;
                }
            }
        }

        public void SetKingFightPos(byte posX, byte posY, char[,] board, byte size)
        {
            // Upper-Left-Diagonal
            if (posX - 1 >= 0 && posY - 1 >= 0)
            {
                board[posX - 1, posY - 1] = fight;
            }
            // Upper-Vertical
            if (posX - 1 >= 0)
            {
                board[posX - 1, posY] = fight;
            }
            // Upper-Right-Diagonal
            if (posX - 1 >= 0 && posY + 1 < size)
            {
                board[posX - 1, posY + 1] = fight;
            }
            //-------------------------------------
            // Left-Horizontal
            if (posY - 1 >= 0)
            {
                board[posX, posY - 1] = fight;
            }
            // Right-Horizontal
            if (posY + 1 < size)
            {
                board[posX, posY + 1] = fight;
            }
            //-------------------------------------
            // Down-Left-Diagonal
            if (posX + 1 < size && posY - 1 >= 0)
            {
                board[posX + 1, posY - 1] = fight;
            }
            // Down-Vertical
            if (posX + 1 < size)
            {
                board[posX + 1, posY] = fight;
            }
            // Down-Right-Diagonal
            if (posX + 1 < size && posY + 1 < size)
            {
                board[posX + 1, posY + 1] = fight;
            }
        }
    }
}

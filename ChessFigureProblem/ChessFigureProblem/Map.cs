using System;

namespace ChessFigureProblem
{
    class Map : IMap
    {
        private readonly byte size;
        private const char fight = 'x';
        private char[,] board;

        public byte GetSize
        {
            get
            {
                byte _size = size;
                return _size;
            }
        }

        public Map(byte _size = 1)
        {
            size = _size;
            board = new char[size, size];
        }

        public void ShowMap(char look)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == look)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (board[i, j] == 'x')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write($"[{board[i, j]}]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        public void SetOnMap(byte posX, byte posY, char look)
        {
            switch (look)
            {
                case '\u2659': // Pawn
                    board[posX, posY] = look;
                    SetPawnFightPos(ref posX,ref posY, look);
                    break;
                case '\u2658': // Knight
                    board[posX, posY] = look;
                    SetKnightFightPos(posX, posY);
                    break;
                case '\u2657': // Bishop
                    board[posX, posY] = look;
                    SetBishopFightPos(posX, posY);
                    break;
                case '\u2656': // Rook
                    board[posX, posY] = look;
                    SetRookFightPos(posX, posY);
                    break;
                case '\u2655': // Queen
                    board[posX, posY] = look;
                    SetQueenFightPos(posX, posY);
                    break;
                case '\u2654': // King
                    board[posX, posY] = look;
                    SetKingFightPos(posX, posY);
                    break;
                default:
                    break;
            }
        }

        // Figure fighting positions setting methods --------------
        public void SetPawnFightPos(ref byte posX,ref byte posY, char look)
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
                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetPawnFightPos(ref posX, ref posY, look);
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
                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetPawnFightPos(ref posX, ref posY, look);
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
                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetPawnFightPos(ref posX, ref posY, look);
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
                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetPawnFightPos(ref posX, ref posY, look);
                    }
                }
            }
        }

        public void SetKnightFightPos(byte posX, byte posY)
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
            // -------------------------------------------------
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

        public void SetBishopFightPos(byte posX, byte posY)
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

        public void SetRookFightPos(byte posX, byte posY)
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

        public void SetQueenFightPos(byte posX, byte posY)
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

        public void SetKingFightPos(byte posX, byte posY)
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
        // --------------------------------------------------------

        public bool IsFreeSpace(byte posX, byte posY, char look)
        {
            if (board[posX, posY] != look && board[posX, posY] != fight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

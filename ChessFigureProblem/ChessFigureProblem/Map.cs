using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessFigureProblem
{
    class Map
    {
        private readonly byte size;
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
            board[posX, posY] = look;

            // Up-Left-Up-Fight-Pos
            if (posX - 2 >= 0 && posY - 1 >= 0)
            {
                board[posX - 2, posY - 1] = 'x';
            }
            // Up-Left-Down-Fight-Pos
            if (posX - 1 >= 0 && posY - 2 >= 0)
            {
                board[posX - 1, posY - 2] = 'x';
            }
            // Up-Right-Up-Fight-Pos
            if (posX - 2 >= 0 && posY + 1 < size)
            {
                board[posX - 2, posY + 1] = 'x';
            }
            // Up-Right-Down-Fight-Pos
            if (posX - 1 >= 0 && posY + 2 < size)
            {
                board[posX - 1, posY + 2] = 'x';
            }
            // -------------------------------------------------
            // Down-Left-Up-Fight-Pos
            if (posX + 1 < size && posY - 2 >= 0)
            {
                board[posX + 1, posY - 2] = 'x';
            }
            // Down-Left-Down-Fight-Pos
            if (posX + 2 < size && posY - 1 >= 0)
            {
                board[posX + 2, posY - 1] = 'x';
            }
            // Down-Right-Up-Fight-Pos
            if (posX + 1 < size && posY + 2 < size)
            {
                board[posX + 1, posY + 2] = 'x';
            }
            // Down-Right-Down-Fight-Pos
            if (posX + 2 < size && posY + 1 < size)
            {
                board[posX + 2, posY + 1] = 'x';
            }
        }

        public bool IsFreeSpace(byte posX, byte posY, char look)
        {
            if (board[posX, posY] != look && board[posX, posY] != 'x')
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

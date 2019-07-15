using System;

namespace ChessFigureProblem
{
    class Map : IMap
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
            if (!IsMapEmpty())
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
        }

        public void SetUserOnMap(Point point, CustomFigure customFig, string moves, byte spaces, ref byte countFigures)
        {
            byte _posX = point.GetX;
            byte _posY = point.GetY;

            customFig.SetUserFightPos(ref _posX, ref _posY, moves, spaces, ref countFigures, board, size);
            board[_posX, _posY] = customFig.GetLook;
        }

        public void SetOnMap(Point point, ChessFigure figure, ref byte countFigures)
        {
            byte posX = point.GetX;
            byte posY = point.GetY;

            switch (figure.GetLook)
            {
                case '\u2659': // Pawn
                    figure.SetPawnFightPos(ref posX, ref posY, ref countFigures, board, size);
                    board[posX, posY] = figure.GetLook;
                    break;
                case '\u2658': // Knight
                    board[posX, posY] = figure.GetLook;
                    figure.SetKnightFightPos(posX, posY, board, size);
                    break;
                case '\u2657': // Bishop
                    board[posX, posY] = figure.GetLook;
                    figure.SetBishopFightPos(posX, posY, board, size);
                    break;
                case '\u2656': // Rook
                    board[posX, posY] = figure.GetLook;
                    figure.SetRookFightPos(posX, posY, board, size);
                    break;
                case '\u2655': // Queen
                    board[posX, posY] = figure.GetLook;
                    figure.SetQueenFightPos(posX, posY, board, size);
                    break;
                case '\u2654': // King
                    board[posX, posY] = figure.GetLook;
                    figure.SetKingFightPos(posX, posY, board, size);
                    break;
            }
        }

        public void ClearMap()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = '\0';
                }
            }
        }
         
        public bool IsFreeSpace(byte posX, byte posY, ChessFigure figure)
        {
            if (board[posX, posY] != figure.GetLook && board[posX, posY] != figure.GetFight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMapEmpty()
        {
            int countEmpty = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        countEmpty++;
                    }
                }
            }

            if (countEmpty == size * size)
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

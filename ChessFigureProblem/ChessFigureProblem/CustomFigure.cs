using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessFigureProblem
{
    class CustomFigure : ChessFigure
    {
        public CustomFigure(char _look) : base(_look)
        {
            look = _look;
        }

        public void SetUserFightPos(ref byte posX, ref byte posY, string moves, byte spaces, ref byte count, char[,] board, byte size)
        {
            Random rnd = new Random();
            string[] _moves = moves.Split(' ');

            for (int i = 0; i < _moves.Length; i++)
            {
                switch (_moves[i])
                {
                    // Diagonals
                    case "lud":
                        SetLeftUpperDiagonal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);
                        break;
                    case "rud":
                        SetRightUpperDiagonal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    case "lld":
                        SetLeftLowerDiagonal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    case "rld":
                        SetRightLowerDiagonal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    // Horizontals
                    case "lh":
                        SetLeftHorizontal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    case "rh":
                        SetRightHorizontal(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    // Verticals
                    case "uv":
                        SetUpperVertical(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                    case "lv":
                        SetLowerVertical(rnd, ref posX, ref posY, board, size, spaces, ref count, moves);                        
                        break;
                }
            }
        }

        private void SetLowerVertical(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX + j < size)
                {
                    if (board[posX + j, posY] != look)
                    {
                        board[posX + j, posY] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX - j >= 0)
                        {
                            board[posX - j, posY] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetUpperVertical(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX - j >= 0)
                {
                    if (board[posX - j, posY] != look)
                    {
                        board[posX - j, posY] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX + j < size)
                        {
                            board[posX + j, posY] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetRightHorizontal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posY + j < size)
                {
                    if (board[posX, posY + j] != look)
                    {
                        board[posX, posY + j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posY - j >= 0)
                        {
                            board[posX, posY - j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetLeftHorizontal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posY - j >= 0)
                {
                    if (board[posX, posY - j] != look)
                    {
                        board[posX, posY - j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posY + j < size)
                        {
                            board[posX, posY + j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetRightLowerDiagonal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX + j < size && posY + j < size)
                {
                    if (board[posX + j, posY + j] != look)
                    {
                        board[posX + j, posY + j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX + j < size && posY - j >= 0)
                        {
                            board[posX + j, posY - j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetLeftLowerDiagonal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX + j < size && posY - j >= 0)
                {
                    if (board[posX + j, posY - j] != look)
                    {
                        board[posX + j, posY - j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX + j < size && posY + j < size)
                        {
                            board[posX + j, posY + j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetRightUpperDiagonal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX - j >= 0 && posY + j < size)
                {
                    if (board[posX - j, posY + j] != look)
                    {
                        board[posX - j, posY + j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX - j >= 0 && posY - j >= 0)
                        {
                            board[posX - j, posY - j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }

        private void SetLeftUpperDiagonal(Random rnd, ref byte posX, ref byte posY, char[,] board, byte size, byte spaces, ref byte count, string moves)
        {
            for (int j = 1; j <= spaces; j++)
            {
                if (posX - j >= 0 && posY - j >= 0)
                {
                    if (board[posX - j, posY - j] != look)
                    {
                        board[posX - j, posY - j] = fight;
                    }
                    else
                    {
                        count--;
                        if (posX - j >= 0 && posY + j < size)
                        {
                            board[posX - j, posY + j] = '\0';
                        }

                        posX = (byte)rnd.Next(0, size);
                        posY = (byte)rnd.Next(0, size);

                        SetUserFightPos(ref posX, ref posY, moves, spaces, ref count, board, size);
                    }
                }
            }
        }
    }
}

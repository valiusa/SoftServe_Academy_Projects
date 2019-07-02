using System;
using System.Text;

namespace ChessFigureProblem
{
    class Chess
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ShowPicks();

            string command = "";

            while (command != "stop")
            {
                Console.Write(" Pick Figure: ");
                char fig = char.Parse(Console.ReadLine());

                Point p = new Point();
                Figure figure = new Figure(fig);

                try
                {
                    Console.Write(" Map Size: ");
                    byte size = byte.Parse(Console.ReadLine());

                    Map map = new Map(size);

                    SettingTheBoard(map, p, figure);

                    map.ShowMap(figure.GetLook);

                    command = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine();
                    Console.WriteLine(" The size is too big!\n Pick size from 0 to 255!");
                    Console.WriteLine();
                }
            }
        }

        private static void SettingTheBoard(Map _map, Point _point, Figure _figure)
        {
            int solNum = 1;

            GetSolution(_map, _point, _figure, ref solNum);

            PrintNumberOfSolForQAndK(_figure.GetLook, solNum, _map); // Prints how many solutions were tryed for The Queen and for the King in 3x3 array
        }

        private static void GetSolution(Map _map, Point _point, Figure _figure, ref int _solNum)
        {
            Random rnd = new Random();

            byte size = _map.GetSize;
            byte countFigures = 0;
            byte countUnsuccessful = 0;

            while (countFigures != size)
            {
                _point.SetX = (byte)rnd.Next(0, size);
                _point.SetY = (byte)rnd.Next(0, size);

                if (_map.IsFreeSpace(_point.GetX, _point.GetY, _figure.GetLook))
                {
                    if (_figure.GetLook == '\u2655' && (size == 2 || size == 3)) // If Queen
                    {
                        Console.WriteLine(" There is no solution for the current map size.");
                        break;
                    }
                    else if (_figure.GetLook == '\u2654' && size == 2)
                    {
                        Console.WriteLine(" There is no solution for the current map size.");
                        break;
                    }
                    else
                    {
                        countFigures++;
                        _map.SetOnMap(_point.GetX, _point.GetY, _figure.GetLook, ref countFigures);                        
                    }
                }
                else
                {
                    countUnsuccessful++;

                    if (countUnsuccessful == size)
                    {
                        _map.ClearMap();
                        countFigures = 0;
                        _solNum++;
                    }
                }
            }
        }

        private static void PrintNumberOfSolForQAndK(char _look, int _solNum, Map _map)
        {
            if ((_look == '\u2655' || (_look == '\u2654' && _map.GetSize == 3)) && !_map.IsMapEmpty())
            {
                Console.WriteLine();
                Console.WriteLine($" Solution(s): {_solNum}");
            }
        }

        private static void ShowPicks()
        {
            Console.WriteLine(" -----------------------------------------------------");
            Console.WriteLine("| p => \u2659 | k => \u2658 | b => \u2657 | r => \u2656 | Q => \u2655 | K => \u2654 |");
            Console.WriteLine(" -----------------------------------------------------");
        }
    }
}

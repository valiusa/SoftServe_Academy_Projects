using System;
using System.Text;

namespace ChessFigureProblem
{
    class Chess
    {
        static void Main(string[] args)
        {
            StartProgram();
        }

        private static void StartProgram()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Point point = new Point();

            byte size = 0;
            byte spaces = 0;

            char fig;

            string command = "";
            string moves = "";

            ShowPicks();            

            while (command != "stop")
            {
                Console.Write(" Pick Figure: ");
                fig = char.Parse(Console.ReadLine());                

                if (IsUserDefindFig(fig))
                {
                    CustomFigure customFig = new CustomFigure(fig);

                    Console.Write(" Choose figure fighting positons: ");
                    moves = Console.ReadLine();

                    Console.Write(" Choose figure fighting spaces: ");
                    spaces = byte.Parse(Console.ReadLine());                    

                    try
                    {
                        Console.Write(" Map Size: ");
                        size = byte.Parse(Console.ReadLine());

                        if (spaces > size) spaces = size;

                        Map map = new Map(size);

                        SettingTheBoardForUser(map, point, customFig, moves, spaces);
                        map.ShowMap(customFig.GetLook);
                    }
                    catch (OverflowException)
                    {
                        OverflowMessage();                        
                    }
                }
                else
                {
                    ChessFigure figure = new ChessFigure(fig);

                    try
                    {
                        Console.Write(" Map Size: ");
                        size = byte.Parse(Console.ReadLine());

                        Map map = new Map(size);

                        SettingTheBoard(map, point, figure);
                        map.ShowMap(figure.GetLook);
                    }
                    catch (OverflowException)
                    {
                        OverflowMessage();
                    }
                }

                command = Console.ReadLine();                
            }
        }

        private static void OverflowMessage()
        {
            Console.WriteLine();
            Console.WriteLine(" The size is too big or too small!\n Pick size from 0 to 255!");
            Console.WriteLine();
        }

        private static void SettingTheBoardForUser(Map map, Point point, CustomFigure customFig, string moves, byte spaces)
        {
            Random rnd = new Random();

            byte size = map.GetSize;
            byte countFigures = 0;
            byte countUnsuccessful = 0;

            while (countFigures != size)
            {
                point.SetX = (byte)rnd.Next(0, size);
                point.SetY = (byte)rnd.Next(0, size);

                if (map.IsFreeSpace(point.GetX, point.GetY, customFig))
                {
                    countFigures++;
                    map.SetUserOnMap(point, customFig, moves, spaces, ref countFigures);                    
                }
                else
                {
                    countUnsuccessful++;

                    if (countUnsuccessful == size * size)
                    {
                        map.ClearMap();
                        Console.WriteLine(" There may be no solution for the current figure!\n Please try again!");
                        break;
                    }
                }
            }
        }

        private static bool IsUserDefindFig(char look)
        {
            if (look != 'p' && look != 'k' && look != 'b' && look != 'r' && look != 'Q' && look != 'K')
                return true;
            else
                return false;
        }

        private static void SettingTheBoard(Map _map, Point _point, ChessFigure _figure)
        {
            int solNum = 0;

            GetSolution(_map, _point, _figure, ref solNum);

            PrintNumberOfSolForQAndK(_figure.GetLook, solNum, _map); // Prints how many solutions were tryed for The Queen and for the King in 3x3 array
        }

        private static void GetSolution(Map _map, Point _point, ChessFigure _figure, ref int _solNum)
        {
            Random rnd = new Random();

            byte size = _map.GetSize;
            byte countFigures = 0;
            byte countUnsuccessful = 0;

            while (countFigures != size)
            {
                _point.SetX = (byte)rnd.Next(0, size);
                _point.SetY = (byte)rnd.Next(0, size);

                if (_map.IsFreeSpace(_point.GetX, _point.GetY, _figure))
                {
                    if (_figure.GetLook == '\u2655' && (size == 2 || size == 3)) // If Queen
                    {
                        Console.WriteLine(" There is no solution for the current map size.");
                        break;
                    }
                    else if (_figure.GetLook == '\u2654' && size == 2) // If King
                    {
                        Console.WriteLine(" There is no solution for the current map size.");
                        break;
                    }
                    else
                    {
                        countFigures++;
                        _map.SetOnMap(_point, _figure, ref countFigures);
                    }
                }
                else
                {
                    countUnsuccessful++;

                    if (countUnsuccessful == size / 2)
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
            Console.WriteLine(" -------------------------------------------------------------------------------------------------");
            Console.WriteLine("|               p => \u2659 | k => \u2658 | b => \u2657 | r => \u2656 | Q => \u2655 | K => \u2654 | User => User                |");
            Console.WriteLine("|-------------------------------------------------------------------------------------------------|");
            Console.WriteLine("| Left Upper Diagonal => lud                                                                      |");
            Console.WriteLine("| Left Lower Diagonal => lld                                                                      |");
            Console.WriteLine("| Right Upper Diagonal => rud                                                                     |");
            Console.WriteLine("| Right Lower Diagonal => rld                                                                     |");
            Console.WriteLine("| Left Horizontal => lh                                                                           |");
            Console.WriteLine("| Right Horizontal => rh                                                                          |");
            Console.WriteLine("| Upper Vertical => uv                                                                            |");
            Console.WriteLine("| Lower Vertical => lv                                                                            |");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------");
        }
    }
}

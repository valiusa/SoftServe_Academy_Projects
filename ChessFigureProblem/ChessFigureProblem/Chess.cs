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

            Console.Write(" Pick Figure: ");
            char fig = char.Parse(Console.ReadLine());

            Point p = new Point();
            Figure figObj = new Figure(fig);

            Console.Write(" Map Size: ");
            byte size = byte.Parse(Console.ReadLine());

            Map map = new Map(size);

            SettingTheBoard(map, p, figObj);

            map.ShowMap(figObj.GetLook);
        }

        private static void SettingTheBoard(Map map, Point p, Figure figObj)
        {
            Random rnd = new Random();

            int solNumb = 1;

            byte size = map.GetSize;
            byte countFigures = 0;
            byte countUnsuccessful = 0;

            while (countFigures < size)
            {
            Again:
                p.SetX = (byte)rnd.Next(0, size);
                p.SetY = (byte)rnd.Next(0, size);

                if (figObj.GetLook == '\u2655' || figObj.GetLook == '\u2654')
                {
                    if (map.IsFreeSpace(p.GetX, p.GetY, figObj.GetLook))
                    {
                        if (figObj.GetLook == '\u2655' && (map.GetSize == 2 || map.GetSize == 3)) // If Queen
                        {
                            Console.WriteLine(" There is no solution for the current map size.");
                            break;
                        }
                        else if (figObj.GetLook == '\u2654' && map.GetSize == 2)
                        {
                            Console.WriteLine(" There is no solution for the current map size.");
                            break;
                        }
                        else
                        {
                            map.SetOnMap(p.GetX, p.GetY, figObj.GetLook);
                            countFigures++;
                        }
                    }
                    else
                    {
                        countUnsuccessful++;

                        if (countUnsuccessful == size)
                        {
                            map.ClearMap();
                            countFigures = 0;
                            solNumb++;

                            goto Again; // goto Line 42
                        }
                    }
                }
                else
                {
                    if (map.IsFreeSpace(p.GetX, p.GetY, figObj.GetLook))
                    {
                        map.SetOnMap(p.GetX, p.GetY, figObj.GetLook);
                        countFigures++;
                    }
                }
            }

            PrintNumberOfSolForQAndK(figObj.GetLook, solNumb, map); // Prints how many solutions were tryed for The Queen and for the King in 3x3 array
        }

        private static void PrintNumberOfSolForQAndK(char look, int solNumb, Map map)
        {
            if ((look == '\u2655' || look == '\u2654') && !map.IsMapEmpty())
            {
                Console.WriteLine();
                Console.WriteLine($" Solution(s): {solNumb}");
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

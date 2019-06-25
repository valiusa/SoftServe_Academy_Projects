using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            byte countUnsuccessful = 0;

            StartSetting(map, p, figObj, ref countUnsuccessful);

            map.ShowMap(figObj.GetLook);
        }

        private static void StartSetting(Map map, Point p, Figure figObj, ref byte countUnsuccessful)
        {
            Random rnd = new Random();

            byte size = map.GetSize;
            byte countFigures = 0;

            while (countFigures < size)
            {
                p.SetX = (byte)rnd.Next(0, size);
                p.SetY = (byte)rnd.Next(0, size);

                if (map.IsFreeSpace(p.GetX, p.GetY, figObj.GetLook))
                {
                    map.SetOnMap(p.GetX, p.GetY, figObj.GetLook);
                    countFigures++;
                }
                else
                {
                    countUnsuccessful++;
                    if (countUnsuccessful == (size * size) * 2)
                    {
                        Console.WriteLine("No Solution Found!");
                        Console.WriteLine("Try Again.");
                        break;
                    }
                }
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

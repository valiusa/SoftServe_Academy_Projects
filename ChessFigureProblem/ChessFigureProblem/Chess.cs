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
            Point p = new Point();
            Random rnd = new Random();
            Figure horse = new Figure('H');

            Console.Write("Set map size: ");
            byte size = byte.Parse(Console.ReadLine());

            Map map = new Map(size);
           
            byte countHorses = 0;

            while (countHorses < size)
            {
                p.SetX = (byte)rnd.Next(0, size);
                p.SetY = (byte)rnd.Next(0, size);
                if (map.IsFreeSpace(p.GetX, p.GetY, horse.GetLook))
                {
                    map.SetOnMap(p.GetX, p.GetY, horse.GetLook);
                    countHorses++;
                }             
            }

            map.ShowMap(horse.GetLook);
        }
    }
}

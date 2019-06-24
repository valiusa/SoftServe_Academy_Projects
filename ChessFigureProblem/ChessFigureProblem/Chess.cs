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


            byte posX = (byte)rnd.Next(0, size);
            byte posY = (byte)rnd.Next(0, size);
            byte countHorses = 0;

            while (countHorses < size)
            {
                if (map.IsFreeSpace(posX, posY, horse.GetLook))
                {
                    map.SetOnMap(posX, posY, horse.GetLook);
                    countHorses++;
                }

                posX = (byte)rnd.Next(0, size);
                posY = (byte)rnd.Next(0, size);                
            }

            map.ShowMap(horse.GetLook);
        }
    }
}

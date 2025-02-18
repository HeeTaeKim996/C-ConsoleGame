using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using MakeMovingGame;
using makeMovingGame;

namespace MakeMovingGame
{
    public class RenderClass
    {
        public static void Render()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(Program.array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Time : {(DateTime.Now - Program.gameStartTime).ToString("ss")} / Score : {Program.score}");

        }
    }
}

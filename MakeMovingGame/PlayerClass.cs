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
    public class PlayerClass
    {
        public static int playerRowInt { get; private set; } = 1;
        public static int playerColumnInt { get; private set; } = 1;

        public static void UpdateInputKey()
        {
            if (!Console.KeyAvailable) return;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            int pastRowInt = playerRowInt;
            int pastColumnInt = playerColumnInt;

            switch (keyInfo.Key)
            {
                case ConsoleKey.D:
                    if (playerColumnInt < Program.maxColumnInt - 2)
                    {
                        playerColumnInt++;
                    }
                    break;
                case ConsoleKey.W:
                    if (playerRowInt > 1)
                    {
                        playerRowInt--;
                    }
                    break;
                case ConsoleKey.A:
                    if (playerColumnInt > 1)
                    {
                        playerColumnInt--;
                    }
                    break;
                case ConsoleKey.S:
                    if (playerRowInt < Program.maxRowInt - 2)
                    {
                        playerRowInt++;
                    }
                    break;
            }

            Program.array[pastRowInt, pastColumnInt] = ' ';
            if (Program.array[playerRowInt, playerColumnInt] == 'S')
            {
                Program.score++;
                Program.array[playerRowInt, playerColumnInt] = 'P';
            }
            else if (Program.array[playerRowInt, playerColumnInt] == 'E')
            {
                Program.InvokeGameOver();
                RenderClass.Render();
                Console.WriteLine("GameOVer");
            }
            else
            {
                Program.array[playerRowInt, playerColumnInt] = 'P';
            }

        }
    }
}

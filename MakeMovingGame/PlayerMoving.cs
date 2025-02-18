using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMovingGame
{
    public class PlayerMoving
    {
        private static char[,] array = new char [10,10];

        private static int playerRowInt = 2;
        private static int playerColumnInt = 3;

        public static void MakePlace()
        {
            for(int j = 0; j < 10; j++)
            {
                array[0, j] = '*';
                array[9, j] = '*';
            }
            for(int i = 1; i < 9; i++)
            {
                array[i, 0] = '*';
                array[i, 9] = '*';
            }
        }
        public static void Render()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(array[i,j]);
                }
                Console.WriteLine();
            }
        }
       
        public static void UpdateInputKey()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        Console.WriteLine("W Input Check");
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("A Input Check");
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("S Input Check");
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("D Input Check");
                        break;
                }
            }
        }
    }
}

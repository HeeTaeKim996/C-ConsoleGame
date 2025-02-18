using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makeMovingGame;
using MakeMovingGame;

namespace MakeMovingGame
{
    public class EnemyClass
    {


        public static int enemyRowInt { get; private set; } = 6;
        public static int enemyColumnInt { get; private set; } = 6;

        public static void EnemyController()
        {
            bool didMove = false;

            int pastEnemyRowInt = enemyRowInt;
            int pastEnemyColumnInt = enemyColumnInt;

            int randomtInt = Random.Shared.Next(0, 2);

            if (randomtInt == 0)
            {
                ColumnMove();
                RowMove();
            }
            else
            {
                RowMove();
                ColumnMove();
            }

            void ColumnMove()
            {
                if (!didMove)
                {
                    if (PlayerClass.playerColumnInt > enemyColumnInt)
                    {
                        enemyColumnInt++;
                        didMove = true;
                    }
                    else if (PlayerClass.playerColumnInt < enemyColumnInt)
                    {
                        enemyColumnInt--;
                        didMove = true;
                    }
                }
            }
            void RowMove()
            {
                if (!didMove)
                {
                    if (PlayerClass.playerRowInt > enemyRowInt)
                    {
                        enemyRowInt++;
                        didMove = true;
                    }
                    else if (PlayerClass.playerRowInt < enemyRowInt)
                    {
                        enemyRowInt--;
                        didMove = true;
                    }
                }

            }

            Program.array[pastEnemyRowInt, pastEnemyColumnInt] = ' ';

            if (Program.array[enemyRowInt, enemyColumnInt] == 'P')
            {
                Program.InvokeGameOver();
            }
            Program.array[enemyRowInt, enemyColumnInt] = 'E';

            RenderClass.Render();
            Console.WriteLine("GameOver!");


        }
    }
}

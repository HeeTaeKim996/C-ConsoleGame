

using System.Drawing;
using MakeMovingGame;

namespace makeMovingGame
{

    public class Program
    {
        static void Main(string[] args)
        {
            MakePlace();
            Update();
        }

        private static void Update()
        {
            while (true)
            {

                DateTime now = DateTime.Now;
                if ((now - dateTime_FixedTime).TotalSeconds > 0.02f)
                {
                    dateTime_FixedTime = now;
                    RenderClass.Render();
                    PlayerClass.UpdateInputKey();
                    ScoreClass.UpdateScoreText(now);
                }

                if ((now - dateTime_MakeScoreText).TotalSeconds > 5f)
                {
                    dateTime_MakeScoreText = now;
                    ScoreClass.MakeScoreText(now);
                }
                if ((now - dateTime_EnemyController).TotalSeconds > 0.6f)
                {
                    dateTime_EnemyController = now;
                    EnemyClass.EnemyController();
                }
            }
        }

        private static DateTime dateTime_FixedTime;
        private static DateTime dateTime_RenderUpdate;
        private static DateTime dateTime_MakeScoreText;
        private static DateTime dateTime_EnemyController;



        public static char[,] array { get; private set; } = new char[10, 10];
        public static int maxRowInt { get; private set; } = 10;
        public static int maxColumnInt { get; private set; } = 10;


        public static DateTime gameStartTime { get; private set; }
        public static int score { get; set; } = 0;

        private static DateTime renderUpdateTime;

        static bool UpdateInputBool = false;
        static bool RenderUpdateBool = false;
        static bool MakeScoreTextBool = false;
        static bool EnemyControllerBool = false;

        public static void MakePlace()
        {
            for (int j = 0; j < maxColumnInt; j++)
            {
                array[0, j] = '*';
                array[maxRowInt - 1, j] = '*';
            }
            for (int i = 1; i < maxRowInt; i++)
            {
                array[i, 0] = '*';
                array[i, maxColumnInt - 1] = '*';
            }
            array[PlayerClass.playerColumnInt, PlayerClass.playerRowInt] = 'P';
            array[EnemyClass.enemyRowInt, EnemyClass.enemyColumnInt] = 'E';

            for (int i = 0; i < maxRowInt; i++)
            {
                for (int j = 0; j < maxColumnInt; j++)
                {
                    if (array[i, j] == '\0')
                    {
                        array[i, j] = ' ';
                    }
                }
            }

            gameStartTime = DateTime.Now;
        }





     
        public static void InvokeGameOver()
        {
            RenderUpdateBool = true;
            UpdateInputBool = true;
            MakeScoreTextBool = true;
            EnemyControllerBool = true;
        }



    }





}


namespace makeMovingGame
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            MakePlace();
            Render();
            Thread updateInputThread = new Thread(new ThreadStart(UpdateInputKey));
            updateInputThread.Start();

            Thread renderUpdateThread = new Thread(new ThreadStart(RenderUpdate));
            renderUpdateThread.Start();

            Thread makeScoreTextThread = new Thread(new ThreadStart(MakeScoreText));
            makeScoreTextThread.Start();

            Thread enemyControllerThread = new Thread(new ThreadStart(EnemyController));
            enemyControllerThread.Start();
        }

        private static char[,] array = new char[10, 10];
        private static int maxRowInt = 10;
        private static int maxColumnInt = 10;

        private static int playerRowInt = 1;
        private static int playerColumnInt = 1;

        private static DateTime gameStartTime ;
        private static int score = 0;

        private static DateTime renderUpdateTime;

        private static int enemyRowInt = 6;
        private static int enemyColumnInt = 6;

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
            array[playerColumnInt, playerRowInt] = 'P';
            array[enemyRowInt, enemyColumnInt] = 'E';

            for(int i = 0; i < maxRowInt; i++)
            {
                for(int j = 0; j < maxColumnInt; j++)
                {
                    if (array[i,j] == '\0')
                    {
                        array[i, j] = ' ';
                    }
                }
            }

            gameStartTime = DateTime.Now;
        }
        public static void RenderUpdate()
        {
            while (true)
            {
                if (RenderUpdateBool) break;

                //Console.WriteLine($"{DateTime.Now} - {renderUpdateTime}");
                if ((DateTime.Now - renderUpdateTime).TotalSeconds > 0.02f)
                {
                    renderUpdateTime = DateTime.Now;
                    Render();
                }
            }
        }
        public static void Render()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Time : {(DateTime.Now - gameStartTime).ToString("ss")} / Score : {score}");
            
        }

        public static void UpdateInputKey()
        {
            while (true)
            {
                if (UpdateInputBool) break;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                int pastRowInt = playerRowInt;
                int pastColumnInt = playerColumnInt;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D:
                        if(playerColumnInt < maxColumnInt-2)
                        {
                            playerColumnInt++;
                        }
                        break;
                    case ConsoleKey.W:
                        if(playerRowInt > 1)
                        {
                            playerRowInt--;
                        }
                        break;
                    case ConsoleKey.A:
                        if(playerColumnInt > 1)
                        {
                            playerColumnInt--;
                        }
                        break;
                    case ConsoleKey.S:
                        if(playerRowInt < maxRowInt - 2)
                        {
                            playerRowInt++;
                        }
                        break;
                }

                array[pastRowInt, pastColumnInt] = ' ';
                if (array[playerRowInt, playerColumnInt] == 'S')
                {
                    score++;
                    array[playerRowInt, playerColumnInt] = 'P';
                }
                else if (array[playerRowInt, playerColumnInt] == 'E')
                {
                    InvokeGameOver();
                    Render();
                    Console.WriteLine("GameOVer");
                }
                else
                {
                    array[playerRowInt, playerColumnInt] = 'P';
                }
            }
        }

        public static void MakeScoreText()
        {
            DateTime makeScoreDateTime = DateTime.Now;
            while (true)
            {
                if (MakeScoreTextBool) break;

                if((DateTime.Now - makeScoreDateTime).TotalSeconds > 5f)
                {
                    makeScoreDateTime = DateTime.Now;

                    Thread thread = new Thread(new ThreadStart(DeleteScoreTextTimer));
                    thread.Start();
                }
            }
        }

        public static void DeleteScoreTextTimer()
        {
            DateTime startTime = DateTime.Now;

            bool didInstantiate = false;

            int rowInt = default;
            int columnInt = default;

            while (!didInstantiate)
            {
                rowInt = Random.Shared.Next(0, maxRowInt);
                columnInt = Random.Shared.Next(0, maxColumnInt);

                if (array[rowInt, columnInt] == ' ')
                {
                    array[rowInt, columnInt] = 'S';
                    didInstantiate = true;
                    startTime = DateTime.Now;
                }
            }


            while((DateTime.Now - startTime).TotalSeconds < 5f)
            {

            }

            if (array[rowInt, columnInt] == 'S')
            {
                array[rowInt, columnInt] = ' ';
            }
        }

        public static void EnemyController()
        {
            DateTime time = DateTime.Now;

            while (true)
            {
                if (EnemyControllerBool) break;

                if ((DateTime.Now - time).TotalSeconds > 0.6f)
                {
                    time = DateTime.Now;

                    bool didMove = false;

                    int pastEnemyRowInt = enemyRowInt;
                    int pastEnemyColumnInt = enemyColumnInt;

                    int randomtInt = Random.Shared.Next(0, 2);

                    if(randomtInt == 0)
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
                            if (playerColumnInt > enemyColumnInt)
                            {
                                enemyColumnInt++;
                                didMove = true;
                            }
                            else if (playerColumnInt < enemyColumnInt)
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
                            if (playerRowInt > enemyRowInt)
                            {
                                enemyRowInt++;
                                didMove = true;
                            }
                            else if (playerRowInt < enemyRowInt)
                            {
                                enemyRowInt--;
                                didMove = true;
                            }
                        }

                    }

                    array[pastEnemyRowInt, pastEnemyColumnInt] = ' ';

                    if (array[enemyRowInt, enemyColumnInt] == 'P')
                    {
                        InvokeGameOver();
                    }
                    array[enemyRowInt, enemyColumnInt] = 'E';

                    Render();
                    Console.WriteLine("GameOver!");
                }
            }
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
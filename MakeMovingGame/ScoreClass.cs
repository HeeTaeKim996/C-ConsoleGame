using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using makeMovingGame;
using MakeMovingGame;

namespace MakeMovingGame
{
    public class ScoreData
    {
        public DateTime deleteTime;
        public int rowInt;
        public int columnInt;
    }

    public class ScoreClass
    {
        private static List<ScoreData> scoreDatas = new List<ScoreData>();

        public static void MakeScoreText(DateTime now)
        {
            bool didInstantiate = false;
            int rowInt = default;
            int columnInt = default;

            while (!didInstantiate)
            {
                rowInt = Random.Shared.Next(0, Program.maxRowInt);
                columnInt = Random.Shared.Next(0, Program.maxColumnInt);

                if (Program.array[rowInt, columnInt] == ' ')
                {
                    Program.array[rowInt, columnInt] = 'S';
                    scoreDatas.Add(new ScoreData { deleteTime = now + TimeSpan.FromSeconds(5f), rowInt = rowInt, columnInt = columnInt });
                    didInstantiate = true;
                }
            }
        }
        public static void UpdateScoreText(DateTime now)
        {
            for (int i = 0; i < scoreDatas.Count; i++)
            {
                if (now >= scoreDatas[i].deleteTime)
                {
                    if (Program.array[scoreDatas[i].rowInt, scoreDatas[i].columnInt] == 'S')
                    {
                        Program.array[scoreDatas[i].rowInt, scoreDatas[i].columnInt] = ' ';
                    }
                    scoreDatas.RemoveAt(i);
                }
            }
        }
    }
}

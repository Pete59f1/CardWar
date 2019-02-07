using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalTurn = 0;
            int infiniteCount = 0;
            Game game = new Game("Peter", "Anders");

            for (int i = 0; i < 10; i++)
            {

                while (!game.IsEndGame())
                {
                    game.Turn();
                }
                if (game.TurnCount < 10)
                {
                    totalTurn += game.TurnCount;
                    infiniteCount++;
                }
            }
            double avgTurn = (double)totalTurn / (double)infiniteCount;
            Console.WriteLine(infiniteCount + " infinite games with an average of " + avgTurn + " turns per game");
            Console.Read();
        }
    }
}

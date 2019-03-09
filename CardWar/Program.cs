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
            Program myProgram = new Program();
            Game game = myProgram.StartGame();

            foreach (Card item in game.Player1.Deck)
            {
                Console.WriteLine(item.DisplayName);
            }
            Console.WriteLine("");
            foreach (Card item in game.Player2.Deck)
            {
                Console.WriteLine(item.DisplayName);
            }
            Console.WriteLine("");

            while (!game.TurnCount.Equals(1000))
            {
                game.Turn();
                Console.WriteLine(game.Player1.Deck.Count + " " + game.Player2.Deck.Count);
                Console.WriteLine("");
            }

        }
        public Game StartGame()
        {
            Game game = new Game("Peter", "Anders");
            return game;
        }
    }
}

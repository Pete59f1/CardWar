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
            foreach (Card card in game.Player1.Deck)
            {
                Console.WriteLine(card.DisplayName + " " + card.Picture);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (Card card in game.Player2.Deck)
            {
                Console.WriteLine(card.DisplayName + " " + card.Picture);
            }

        }
        public Game StartGame()
        {
            Game game = new Game("Peter", "Anders");
            return game;
        }
    }
}

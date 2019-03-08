using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Deck { get; set; }

        public Card DrawCard()
        {
            Card card = Deck[0];
            Deck.RemoveAt(0);
            return card;
        }
    }
}

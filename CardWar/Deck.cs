using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public class Deck
    {
        public static List<Card> GenerateCardDeck()
        {
            List<Card> cards = new List<Card>();

            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card { Suit = suit, Value = i, DisplayName = Card.ShortName(i, suit), Picture = Card.AddPicture(i, suit)});
                }
            }
            return Shuffle(cards);
        }

        private static List<Card> Shuffle(List<Card> cards)
        {
            List<Card> shuffleDeck = cards.ToList();
            Random ran = new Random(DateTime.Now.Millisecond);

            for (int i = shuffleDeck.Count - 1; i > 0; i--)
            {
                int j = ran.Next(i + 1);
                Card temp = shuffleDeck[i];
                shuffleDeck[i] = shuffleDeck[j];
                shuffleDeck[j] = temp;
            }
            return shuffleDeck;
        }
    }
}

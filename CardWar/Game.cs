using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public class Game: IPublisher
    {
        public Player Player1;
        public Player Player2;
        public int TurnCount;
        List<ISubscriber> subs = new List<ISubscriber>();
        

        public Game (string player1name, string player2name)
        {
            List<Card> cards = Deck.GenerateCardDeck();

            Player1 = new Player { Name = player1name };
            Player2 = new Player { Name = player2name };

            List<Card> deck1 = new List<Card>();
            List<Card> deck2 = new List<Card>();

            for (int i = 0, j = 26; i < 26; i++, j++)
            {
                deck1.Add(cards[i]);
                deck2.Add(cards[j]);
            }

            Player1.Deck = deck1;
            Player2.Deck = deck2;
        }

        public void Turn()
        {
            Card player1Card = Player1.DrawCard();
            Card player2Card = Player2.DrawCard();
            if (player1Card.Value == player2Card.Value)
            {
                War(player1Card, player2Card);
            }
            else
            {
                FindWinner(player1Card, player2Card);
            }
            TurnCount++;
            NotifySubscribers();
        }

        private void FindWinner(Card player1card, Card player2card)
        {
            if (player1card.Value < player2card.Value)
            {
                Player2.Deck.Add(player1card);
                Player2.Deck.Add(player2card);
            }
            else
            {
                Player1.Deck.Add(player2card);
                Player1.Deck.Add(player1card);
            }
        }
        private void War(Card player1Card, Card player2Card)
        {
            List<Card> cardpool = new List<Card>();
            cardpool.Add(player1Card);
            cardpool.Add(player2Card);
            cardpool.Add(Player1.DrawCard());
            cardpool.Add(Player2.DrawCard());
            cardpool.Add(Player1.DrawCard());
            cardpool.Add(Player2.DrawCard());

            if (cardpool[4].Value < cardpool[5].Value)
            {
                Player2.Deck.AddRange(cardpool);
            }
            else if (cardpool[4].Value > cardpool[5].Value)
            {
                Player1.Deck.AddRange(cardpool);
            }
            else
            {
                //Ens kort værdi igen. Giv kort tilbage til ejer
                Player1.Deck.Add(cardpool[0]);
                Player1.Deck.Add(cardpool[2]);
                Player1.Deck.Add(cardpool[4]);
                Player2.Deck.Add(cardpool[1]);
                Player2.Deck.Add(cardpool[3]);
                Player2.Deck.Add(cardpool[5]);
            }
        }

        public void RegisterSubscriber(ISubscriber observer)
        {
            subs.Add(observer);
        }

        public void RemoveSubscriber(ISubscriber observer)
        {
            subs.Remove(observer);
        }

        public void NotifySubscribers()
        {
            foreach (ISubscriber sub in subs)
            {
                sub.Update(this);
            }
        }
    }
}

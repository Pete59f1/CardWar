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
            var cardbool = new List<Card>();
            NotifySubscribers();

            Card player1Card = Player1.Deck[0];
            Card player2Card = Player2.Deck[0];

            cardbool.Add(player1Card);
            cardbool.Add(player2Card);

            Player1.Deck.Remove(Player1.Deck[0]);
            Player2.Deck.Remove(Player2.Deck[0]);

            if (player1Card.Value == player2Card.Value)
            {
                War(player1Card, player2Card);
            }

            else if (player1Card.Value < player2Card.Value)
            {
                Player2.Deck.AddRange(cardbool);
            }
            else
            {
                Player1.Deck.AddRange(cardbool);
            }
            TurnCount++;
        }

        private void War(Card player1Card, Card player2Card)
        {
            List<Card> warbool = new List<Card>();
            while (player1Card.Value == player2Card.Value)
            {
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                //Ligger tre kort ned
                Card player1Card2 = Player1.Deck[0];
                Card player2Card2 = Player2.Deck[0];
                warbool.Add(player1Card2);
                warbool.Add(player2Card2);
                Player1.Deck.Remove(Player1.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);
                Card player1Card3 = Player1.Deck[0];
                Card player2Card3 = Player2.Deck[0];
                warbool.Add(player1Card3);
                warbool.Add(player2Card3);
                Player1.Deck.Remove(Player1.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);
                Card player1Card4 = Player1.Deck[0];
                Card player2Card4 = Player2.Deck[0];
                warbool.Add(player1Card4);
                warbool.Add(player2Card4);
                Player1.Deck.Remove(Player1.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);

                //Ligger kort nr 4
                Card player1Card5 = Player1.Deck[0];
                Card player2Card5 = Player2.Deck[0];
                warbool.Add(player1Card5);
                warbool.Add(player2Card5);
                Player1.Deck.Remove(Player1.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);

                if (player1Card5.Value < player2Card5.Value)
                {
                    Player2.Deck.AddRange(warbool);
                }
                else
                {
                    Player1.Deck.AddRange(warbool);
                }
                TurnCount++;
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

﻿using System;
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
        private List<Card> cardpool = new List<Card>();
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
            if (Player1.Deck.Count >= 1 && Player2.Deck.Count >= 1)
            {
                Card player1Card = Player1.DrawCard();
                Card player2Card = Player2.DrawCard();
                War(player1Card, player2Card, cardpool);
            }
            else
            {
                EndGame();
            }

            TurnCount++;
            NotifySubscribers();
        }
        private void EndGame()
        {
            string winner;
            int winnerCount;
            if (Player1.Deck.Count > Player2.Deck.Count)
            {
                winner = Player1.Name;
                winnerCount = Player1.Deck.Count;
            }
            else
            {
                winner = Player2.Name;
                winnerCount = Player2.Deck.Count;
            }
            throw new Exception("Game over " + winner + " is the winner with " + winnerCount + " cards");
        }
        private void War(Card player1Card, Card player2Card, List<Card> pool)
        {
            cardpool.Add(player1Card);
            cardpool.Add(player2Card);
            if (player1Card.Value < player2Card.Value)
            {
                Player2.Deck.AddRange(cardpool);
                cardpool.Clear();
            }
            else if (player1Card.Value > player2Card.Value)
            {
                Player1.Deck.AddRange(cardpool);
                cardpool.Clear();
            }
            else
            {
                if (Player1.Deck.Count >= 4 && Player2.Deck.Count >= 4)
                {
                    cardpool.Add(Player1.DrawCard());
                    cardpool.Add(Player2.DrawCard());
                    cardpool.Add(Player1.DrawCard());
                    cardpool.Add(Player2.DrawCard());
                    cardpool.Add(Player1.DrawCard());
                    cardpool.Add(Player2.DrawCard());
                    Card lastCard1 = Player1.DrawCard();
                    Card lastCard2 = Player2.DrawCard();

                    if (lastCard1.Value < lastCard2.Value)
                    {
                        cardpool.Add(lastCard1);
                        cardpool.Add(lastCard2);
                        Player2.Deck.AddRange(cardpool);
                        cardpool.Clear();
                    }
                    else if (lastCard1.Value > lastCard2.Value)
                    {
                        cardpool.Add(lastCard2);
                        cardpool.Add(lastCard1);
                        Player1.Deck.AddRange(cardpool);
                        cardpool.Clear();
                    }
                    else
                    {
                        War(lastCard1, lastCard2, cardpool);
                    }
                }
                else
                {
                    EndGame();
                }
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

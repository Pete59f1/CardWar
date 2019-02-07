﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardWar;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISubscriber
    {
        Game game;
        int turns;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            game.Turn();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            game = new Game(Player1TB.Text, Player2TB.Text);
            game.RegisterSubscriber(this);
            turns = int.Parse(NumbersofTurnsTB.Text);
            StartUp();
        }

        public void Update(IPublisher publisher)
        {
            Player1CardsLabel.Content = game.Player1.Name + " has " + game.Player1.Deck.Count + " cards left in deck";
            Player2CardsLabel.Content = game.Player2.Name + " has " + game.Player2.Deck.Count + " cards left in deck";
            NumberOfTurnsLabel.Content = "Number of turns " + game.TurnCount + " out of " + turns;
        }

        public void StartUp()
        {
            NextTurnButton.IsEnabled = true;
            NumberOfTurnsLabel.IsEnabled = true;
            WhoIsTheWinnerLabel.IsEnabled = true;
            Player1CardsLabel.IsEnabled = true;
            Player2CardsLabel.IsEnabled = true;

            Player1TB.IsEnabled = false;
            Player2TB.IsEnabled = false;
            NumbersofTurnsTB.IsEnabled = false;
            NewGameButton.IsEnabled = false;

            Player1CardsLabel.Content = game.Player1.Name + " has " + game.Player1.Deck.Count + " cards left in deck";
            Player2CardsLabel.Content = game.Player2.Name + " has " + game.Player2.Deck.Count + " cards left in deck";
            NumberOfTurnsLabel.Content = "Number of turns " + game.TurnCount + " out of " + turns;
        }
    }
}

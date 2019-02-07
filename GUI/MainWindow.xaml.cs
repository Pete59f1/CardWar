using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            //while (!game.IsEndGame())
            //{
            //    game.Turn();
            //    //ImagePlayerOne.Source = game.Player1.Deck[0].Picture;
            //    NumberOfTurnsLabel.Content = "Numbers of turns: " + game.TurnCount;
            //}
            //if (game.IsEndGame())
            //{
            //    NextTurnButton.IsEnabled = false;
            //    NumberOfTurnsLabel.IsEnabled = false;
            //    WhoIsTheWinnerLabel.IsEnabled = false;
            //}
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            game = new Game(Player1TB.Text, Player2TB.Text);
            game.RegisterSubscriber(this);
            NextTurnButton.IsEnabled = true;
            NumberOfTurnsLabel.IsEnabled = true;
            WhoIsTheWinnerLabel.IsEnabled = true;
            Player1CardsLabel.IsEnabled = true;
            Player2CardsLabel.IsEnabled = true;
        }

        public void Update(IPublisher publisher)
        {
            Player1CardsLabel.Content = game.Player1.Deck.Count;
            Player2CardsLabel.Content = game.Player2.Deck.Count;
            NumberOfTurnsLabel.Content = game.TurnCount;
        }
    }
}

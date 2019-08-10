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

namespace Yahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();

            Image_Dice1.Source = game.DefaultBitmap;
            Image_Dice2.Source = game.DefaultBitmap;
            Image_Dice3.Source = game.DefaultBitmap;
            Image_Dice4.Source = game.DefaultBitmap;
            Image_Dice5.Source = game.DefaultBitmap;
        }

        private void Button_Dice_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)(sender);
            switch (button.Content)
            {
                case "1":
                    Image_Dice1.Source = game.Lock(1); break;
                case "2":
                    Image_Dice2.Source = game.Lock(2); break;
                case "3":
                    Image_Dice3.Source = game.Lock(3); break;
                case "4":
                    Image_Dice4.Source = game.Lock(4); break;
                case "5":
                    Image_Dice5.Source = game.Lock(5); break;
            }
        }

        private void Button_Roll_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice1.Source = game.Roll(1);
            Image_Dice2.Source = game.Roll(2);
            Image_Dice3.Source = game.Roll(3);
            Image_Dice4.Source = game.Roll(4);
            Image_Dice5.Source = game.Roll(5);
        }

        private void Button_Pattern_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)(sender);
            button.IsEnabled = false;

            switch (button.Content)
            {
                case "Ones":
                    TextBox_Ones.Text = game.ScoreNumbers(1); break;
                case "Twos":
                    TextBox_Twos.Text = game.ScoreNumbers(2); break;
                case "Threes":
                    TextBox_Threes.Text = game.ScoreNumbers(3); break;
                case "Fours":
                    TextBox_Fours.Text = game.ScoreNumbers(4); break;
                case "Fives":
                    TextBox_Fives.Text = game.ScoreNumbers(5); break;
                case "Sixes":
                    TextBox_Sixes.Text = game.ScoreNumbers(6); break;
                case "Three of a Kind":
                    TextBox_ThreeOfAKind .Text = game.ScoreOfAKind(3); break;
                case "Carre":
                    TextBox_Carre.Text = game.ScoreOfAKind(4); break;
                case "Yahtzee":
                    TextBox_Yahtzee.Text = game.ScoreYahtzee(); break;
                case "Chance":
                    TextBox_Chance.Text = game.ScoreChance(); break;
            }

            Image_Dice1.Source = game.Reset(1);
            Image_Dice2.Source = game.Reset(2);
            Image_Dice3.Source = game.Reset(3);
            Image_Dice4.Source = game.Reset(4);
            Image_Dice5.Source = game.Reset(5);
        }
    }
}

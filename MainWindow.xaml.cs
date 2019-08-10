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
            game.Roll();

            Image_Dice1.Source = game.GetBitmap(1);
            Image_Dice2.Source = game.GetBitmap(2);
            Image_Dice3.Source = game.GetBitmap(3);
            Image_Dice4.Source = game.GetBitmap(4);
            Image_Dice5.Source = game.GetBitmap(5);

            if (game.Rolls == 3)
                Button_Roll.IsEnabled = false;
        }

        private int TextBoxNumber(TextBox textbox)
        {
            if (textbox.Text != "")
                return Convert.ToInt32(textbox.Text);
            return 0;
        }

        private void Button_Pattern_Click(object sender, RoutedEventArgs e)
        {
            if (game.Rolls == 0) return;

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
                case "Full House":
                    TextBox_FullHouse.Text = game.ScoreFullHouse(); break;
                case "Small Street":
                    TextBox_SmallStreet.Text = game.ScoreStreet(false); break;
                case "Big Street":
                    TextBox_BigStreet.Text = game.ScoreStreet(true); break;
                case "Yahtzee":
                    TextBox_Yahtzee.Text = game.ScoreYahtzee(); break;
                case "Chance":
                    TextBox_Chance.Text = game.ScoreChance(); break;
            }

            if (TextBoxNumber(TextBox_Ones) +
                TextBoxNumber(TextBox_Twos) +
                TextBoxNumber(TextBox_Threes) +
                TextBoxNumber(TextBox_Fours) +
                TextBoxNumber(TextBox_Fives) +
                TextBoxNumber(TextBox_Sixes) >= 63)
            {
                TextBox_NumberBonus.Text = "35";
            }

            TextBox_Total.Text =
            (
                TextBoxNumber(TextBox_Ones) +
                TextBoxNumber(TextBox_Twos) +
                TextBoxNumber(TextBox_Threes) +
                TextBoxNumber(TextBox_Fours) +
                TextBoxNumber(TextBox_Fives) +
                TextBoxNumber(TextBox_Sixes) +
                TextBoxNumber(TextBox_NumberBonus) +
                TextBoxNumber(TextBox_ThreeOfAKind) +
                TextBoxNumber(TextBox_Carre) +
                TextBoxNumber(TextBox_FullHouse) +
                TextBoxNumber(TextBox_SmallStreet) +
                TextBoxNumber(TextBox_BigStreet) +
                TextBoxNumber(TextBox_Yahtzee) +
                TextBoxNumber(TextBox_Chance)
            ).ToString();

            game.Reset();

            Image_Dice1.Source = game.DefaultBitmap;
            Image_Dice2.Source = game.DefaultBitmap;
            Image_Dice3.Source = game.DefaultBitmap;
            Image_Dice4.Source = game.DefaultBitmap;
            Image_Dice5.Source = game.DefaultBitmap;

            Button_Roll.IsEnabled = true;
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            game.Reset();

            Image_Dice1.Source = game.DefaultBitmap;
            Image_Dice2.Source = game.DefaultBitmap;
            Image_Dice3.Source = game.DefaultBitmap;
            Image_Dice4.Source = game.DefaultBitmap;
            Image_Dice5.Source = game.DefaultBitmap;

            TextBox_Ones.Text = "";
            TextBox_Twos.Text = "";
            TextBox_Threes.Text = "";
            TextBox_Fours.Text = "";
            TextBox_Fives.Text = "";
            TextBox_Sixes.Text = "";
            TextBox_NumberBonus.Text = "";
            TextBox_ThreeOfAKind.Text = "";
            TextBox_Carre.Text = "";
            TextBox_FullHouse.Text = "";
            TextBox_SmallStreet.Text = "";
            TextBox_BigStreet.Text = "";
            TextBox_Yahtzee.Text = "";
            TextBox_Chance.Text = "";
            TextBox_Total.Text = "";

            Button_Roll.IsEnabled = true;
            Button_Ones.IsEnabled = true;
            Button_Twos.IsEnabled = true;
            Button_Threes.IsEnabled = true;
            Button_Fours.IsEnabled = true;
            Button_Fives.IsEnabled = true;
            Button_Sixes.IsEnabled = true;
            Button_ThreeOfAKind.IsEnabled = true;
            Button_Carre.IsEnabled = true;
            Button_FullHouse.IsEnabled = true;
            Button_SmallStreet.IsEnabled = true;
            Button_BigStreet.IsEnabled = true;
            Button_Yahtzee.IsEnabled = true;
            Button_Chance.IsEnabled = true;
        }
    }
}

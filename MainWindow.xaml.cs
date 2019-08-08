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
        BitmapImage bitmap;
        List<CroppedBitmap> bitmaps;

        public MainWindow()
        {
            InitializeComponent();

            bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("C:\\GitHub\\ITvitae\\Yahtzee\\resources\\dice.png");
            bitmap.EndInit();

            bitmaps = new List<CroppedBitmap>(13);
            CroppedBitmap empty  = new CroppedBitmap(bitmap, new Int32Rect(300,   0, 100, 100));
            CroppedBitmap white1 = new CroppedBitmap(bitmap, new Int32Rect(  0,   0, 100, 100));
            CroppedBitmap white2 = new CroppedBitmap(bitmap, new Int32Rect(100,   0, 100, 100));
            CroppedBitmap white3 = new CroppedBitmap(bitmap, new Int32Rect(200,   0, 100, 100));
            CroppedBitmap white4 = new CroppedBitmap(bitmap, new Int32Rect(  0, 100, 100, 100));
            CroppedBitmap white5 = new CroppedBitmap(bitmap, new Int32Rect(100, 100, 100, 100));
            CroppedBitmap white6 = new CroppedBitmap(bitmap, new Int32Rect(200, 100, 100, 100));
            CroppedBitmap grey1  = new CroppedBitmap(bitmap, new Int32Rect(  0, 200, 100, 100));
            CroppedBitmap grey2  = new CroppedBitmap(bitmap, new Int32Rect(100, 200, 100, 100));
            CroppedBitmap grey3  = new CroppedBitmap(bitmap, new Int32Rect(200, 200, 100, 100));
            CroppedBitmap grey4  = new CroppedBitmap(bitmap, new Int32Rect(  0, 300, 100, 100));
            CroppedBitmap grey5  = new CroppedBitmap(bitmap, new Int32Rect(100, 300, 100, 100));
            CroppedBitmap grey6  = new CroppedBitmap(bitmap, new Int32Rect(200, 300, 100, 100));
            bitmaps.Add( empty);
            bitmaps.Add(white1); bitmaps.Add(white2); bitmaps.Add(white3);
            bitmaps.Add(white4); bitmaps.Add(white5); bitmaps.Add(white6);
            bitmaps.Add( grey1); bitmaps.Add( grey2); bitmaps.Add( grey3);
            bitmaps.Add( grey4); bitmaps.Add( grey5); bitmaps.Add( grey6);
        }

        private void Button_Dice1_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice1.Source = bitmaps[1];
        }

        private void Button_Dice2_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice2.Source = bitmaps[2];
        }

        private void Button_Dice3_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice3.Source = bitmaps[3];
        }

        private void Button_Dice4_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice4.Source = bitmaps[4];
        }

        private void Button_Dice5_Click(object sender, RoutedEventArgs e)
        {
            Image_Dice5.Source = bitmaps[5];
        }
    }
}

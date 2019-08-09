using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Yahtzee
{
    class Game
    {
        List<CroppedBitmap> bitmaps;

        private void InitBitmaps()
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("C:\\GitHub\\ITvitae\\Yahtzee\\resources\\dice.png");
            bitmap.EndInit();

            var empty = new CroppedBitmap(bitmap, new Int32Rect(300, 0, 100, 100));
            var white1 = new CroppedBitmap(bitmap, new Int32Rect(0, 0, 100, 100));
            var white2 = new CroppedBitmap(bitmap, new Int32Rect(100, 0, 100, 100));
            var white3 = new CroppedBitmap(bitmap, new Int32Rect(200, 0, 100, 100));
            var white4 = new CroppedBitmap(bitmap, new Int32Rect(0, 100, 100, 100));
            var white5 = new CroppedBitmap(bitmap, new Int32Rect(100, 100, 100, 100));
            var white6 = new CroppedBitmap(bitmap, new Int32Rect(200, 100, 100, 100));
            var grey1 = new CroppedBitmap(bitmap, new Int32Rect(0, 200, 100, 100));
            var grey2 = new CroppedBitmap(bitmap, new Int32Rect(100, 200, 100, 100));
            var grey3 = new CroppedBitmap(bitmap, new Int32Rect(200, 200, 100, 100));
            var grey4 = new CroppedBitmap(bitmap, new Int32Rect(0, 300, 100, 100));
            var grey5 = new CroppedBitmap(bitmap, new Int32Rect(100, 300, 100, 100));
            var grey6 = new CroppedBitmap(bitmap, new Int32Rect(200, 300, 100, 100));

            bitmaps = new List<CroppedBitmap>(13);
            bitmaps.Add(empty);
            bitmaps.Add(white1); bitmaps.Add(white2); bitmaps.Add(white3);
            bitmaps.Add(white4); bitmaps.Add(white5); bitmaps.Add(white6);
            bitmaps.Add(grey1); bitmaps.Add(grey2); bitmaps.Add(grey3);
            bitmaps.Add(grey4); bitmaps.Add(grey5); bitmaps.Add(grey6);
        }

        private class Die
        {
            public Game game;
            public CroppedBitmap bitmap;
            public bool locked;
            public int number;

            public void Reset()
            {
                bitmap = game.bitmaps[0];
                locked = false;
                number = 0;
            }

            public Die(Game thisGame)
            {
                game = thisGame;
                Reset();
            }

            private void UpdateBitmap()
            {
                if (number > 0)
                {
                    if (locked)
                        bitmap = game.bitmaps[number + 6];
                    else
                        bitmap = game.bitmaps[number];
                }
                else
                {
                    bitmap = game.bitmaps[0];
                }
            }

            public void Toggle()
            {
                if (number > 0)
                    locked = !locked;

                UpdateBitmap();
            }

            public void Roll()
            {
                if (!locked)
                {
                    var random = new Random(Guid.NewGuid().GetHashCode());
                    number = random.Next(1, 7);
                    UpdateBitmap();
                }
            }
        }

        private List<Die> dice;

        private void InitDice()
        {
            dice = new List<Die>(5);
            for (int i = 0; i < 5; i++)
                dice.Add(new Die(this));
        }

        public Game()
        {
            InitBitmaps();
            InitDice();
        }

        public int NumberOfDice => dice.Count;

        public CroppedBitmap DefaultBitmap => bitmaps[0];

        public CroppedBitmap Toggle(int d)
        {
            dice[d - 1].Toggle();
            return dice[d - 1].bitmap;
        }

        public CroppedBitmap Roll(int d)
        {
            dice[d - 1].Roll();
            return dice[d - 1].bitmap;
        }

        public CroppedBitmap GetBitmap(int d)
        {
            return dice[d - 1].bitmap;
        }


    }
}

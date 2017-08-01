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
using System.Windows.Threading;
using System.IO;

namespace Snake_Alicja
{
    struct Point
    {
        public int x;
        public int y;
    }

    public partial class SnakeGame : Window
    {
        private Snake mySnake;    
        private DeadFood deadfood;
        private PremiumFood premfood;
        private int X_Direction = 0;
        private int Y_Direction = 1;
        private DispatcherTimer time;
        private int StarVisible;
        private int amountNormFood;
        private const int SIZE_CELL = 10;
        static public int score;
        static public int recordScore;
        static public string recordUser;
        static public bool premiumFoodVisible = true;
        List<NormalFood> normfoodList = new List<NormalFood>();
        public SnakeGame()
        {
            InitializeComponent(); 
            CreateBoard();
            CreateSnake();
            StartTime();
            MakeFood();            

            score = 0;
            textBlockUser.Text = MainWindow.user_name;
            textBlockScore.Text = score.ToString();

            using (var reader = new StreamReader
                ("C:\\Users\\Alicja\\Documents\\Visual Studio 2015\\Projects\\Snake_Alicja\\Snake_Alicja\\record.txt"))          
            {
                recordUser = reader.ReadLine();
                recordScore = Int16.Parse(reader.ReadLine());
                reader.Close();
            }

            textBlockRekordUser.Text = recordUser;
            textBlockRecordScore.Text = recordScore.ToString();
        }
        void CreateBoard()
        {
            for (int i = 0; i < gridGame.Width / SIZE_CELL; i++)
            {
                ColumnDefinition columnProperties = new ColumnDefinition();
                columnProperties.Width = new GridLength(SIZE_CELL);
                gridGame.ColumnDefinitions.Add(columnProperties);
            }
            for (int j = 0; j < gridGame.Height / SIZE_CELL; j++)
            {
                RowDefinition rowProperties = new RowDefinition();
                rowProperties.Height = new GridLength(SIZE_CELL);
                gridGame.RowDefinitions.Add(rowProperties);
            }
        }
        void CreateSnake()
        {
            mySnake = new Snake();
            gridGame.Children.Add(mySnake.headSnake.Rectangle);

            PartOfSnake part = mySnake.AddParts(31, 30);
            gridGame.Children.Add(part.Rectangle);
            mySnake.DrawSnake();        
        }
        void StartTime()
        {
            time = new DispatcherTimer();
            time.Tick += new EventHandler(TimeUpdate);
            time.Interval = new TimeSpan(0, 0, 0, 0, 90);
            time.Start();
        }
        void MakeFood()
        {
            normfoodList.Add(new NormalFood(40, 35));
            gridGame.Children.Add(normfoodList.ElementAt(0).Rectangle);
            normfoodList.ElementAt(0).Draw();

            deadfood = new DeadFood(30, 10);
            gridGame.Children.Add(deadfood.Rectangle);
            deadfood.Draw();

            premfood = new PremiumFood(40, 2);
            gridGame.Children.Add(premfood.Rectangle);
            premfood.Draw();
        }
        void TimeUpdate(object sender, EventArgs e)
        {
            UpdateGame();
        }
        private void UpdateGame()
        {
            mySnake.updateList(X_Direction, Y_Direction);
            BoardCollision();
            BadColiision();
            GoodCollision();
            mySnake.DrawSnake();    
        }
        void GameOver()
        {
            time.Stop();

            if (CheckRecord(score))
                MessageBox.Show("GAME OVER!  CONGRATULATION!  NEW RECORD! ");
            else
                MessageBox.Show("GAME OVER");
        }
        bool CheckRecord(int result)
        {
            if (result > recordScore)
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Alicja\\Documents\\Visual Studio 2015\\Projects\\Snake_Alicja\\Snake_Alicja\\record.txt");
                sw.WriteLine(MainWindow.user_name);
                sw.WriteLine(score);
                sw.Close();
                return true;
            }

            return false;
        }
        void BoardCollision()
        {
            if (mySnake.headSnake.x < 0 || mySnake.headSnake.x > (gridGame.Width / SIZE_CELL))
                GameOver();
            if (mySnake.headSnake.y < 0 || mySnake.headSnake.y > (gridGame.Height / SIZE_CELL))
                GameOver(); 
        }
        void GoodCollision()
        {
            foreach (NormalFood nfood in normfoodList)
            {
                if (mySnake.headSnake.x == nfood.x && mySnake.headSnake.y == nfood.y)
                {
                    ++score;
                    textBlockScore.Text = score.ToString();
                    PartOfSnake part = mySnake.AddParts(mySnake.partsSnakeList.Last().x, mySnake.partsSnakeList.Last().y);
                    gridGame.Children.Add(part.Rectangle);
                    mySnake.DrawSnake();

                    Random rand1 = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                    amountNormFood = rand1.Next(1, 3);
                    switch (amountNormFood)
                    {
                        case 1:
                            if (normfoodList.Count() == 2)
                            {
                                normfoodList.Remove(nfood);
                                gridGame.Children.Remove(nfood.Rectangle);
                                Point poin = NewLocation();
                                normfoodList.ElementAt(0).x = poin.x;
                                normfoodList.ElementAt(0).y = poin.y;
                                normfoodList.ElementAt(0).Draw();
                            }
                            else 
                            {
                                Point poin = NewLocation();
                                normfoodList.ElementAt(0).x = poin.x;
                                normfoodList.ElementAt(0).y = poin.y;
                                normfoodList.ElementAt(0).Draw();
                            }
                            break;
                        case 2:
                            if (normfoodList.Count() == 1)
                            {
                                Point poin = NewLocation();
                                normfoodList.Add(new NormalFood(poin.x, poin.y));
                                gridGame.Children.Add(normfoodList.ElementAt(1).Rectangle);
                                normfoodList.ElementAt(1).Draw();

                                poin = NewLocation();
                                normfoodList.ElementAt(0).x = poin.x;
                                normfoodList.ElementAt(0).y = poin.y;
                                normfoodList.ElementAt(0).Draw();
                            }
                            else
                            {
                                Point poin = NewLocation();
                                normfoodList.ElementAt(0).x = poin.x;
                                normfoodList.ElementAt(0).y = poin.y;
                                normfoodList.ElementAt(0).Draw();

                                poin = NewLocation();
                                normfoodList.ElementAt(1).x = poin.x;
                                normfoodList.ElementAt(1).y = poin.y;
                                normfoodList.ElementAt(1).Draw();
                            }
                            break;
                    }

                    Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                    StarVisible = rnd.Next(1, 3);

                    if (StarVisible == 1)
                    {
                        if (gridGame.Children.Contains(premfood.Rectangle))
                        {
                            Point point = NewLocation();
                            premfood.x = point.x;
                            premfood.y = point.y;
                            premfood.Draw();
                        }
                        else
                        {
                            Point point = NewLocation();
                            premfood.x = point.x;
                            premfood.y = point.y;
                            gridGame.Children.Add(premfood.Rectangle);
                            premfood.Draw();
                        }
                    }
                    else
                        gridGame.Children.Remove(premfood.Rectangle);

                    Point pt = NewLocation();
                    pt = NewLocation();
                    deadfood.x = pt.x;
                    deadfood.y = pt.y;
                    deadfood.Draw();

                    break;
                }
            }
            
            if (mySnake.headSnake.x == premfood.x && mySnake.headSnake.y == premfood.y)
            {
                score += 10;
                textBlockScore.Text = score.ToString();
                PartOfSnake part = mySnake.AddParts(mySnake.partsSnakeList.Last().x, mySnake.partsSnakeList.Last().y);
                gridGame.Children.Add(part.Rectangle);
                mySnake.DrawSnake();
                gridGame.Children.Remove(premfood.Rectangle);                
            }
        }        
        void BadColiision()
        {
            if (mySnake.headSnake.x == deadfood.x && mySnake.headSnake.y == deadfood.y)
                GameOver();
            foreach (PartOfSnake part in mySnake.partsSnakeList)
            {
                if (mySnake.headSnake.x == part.x && mySnake.headSnake.y == part.y)
                    GameOver();
            }
        }
        Point NewLocation()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Point point = new Point();
            do
            {
                point.x = rnd.Next(0, 43);
                point.y = rnd.Next(0, 53);
            }
            while (!isGridFree(point.x, point.y));

            return point;
        }
        bool isGridFree(int X, int Y)
        {
            if (mySnake.headSnake.x == X && mySnake.headSnake.y == Y)
                return false;
            foreach (NormalFood normF in normfoodList)
            {
                if (normF.x == X && normF.y == Y)
                    return false;
            }
            foreach (PartOfSnake part in mySnake.partsSnakeList)
            {
                if (part.x == X && part.y == Y)
                    return false;
            }
            if (premfood.x == X && premfood.y == Y)
                return false;
            if (deadfood.x == X && deadfood.y == Y)
                return false;
            
            return true;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                if (!(X_Direction == 1))
                { 
                    X_Direction = -1;
                    Y_Direction = 0;
                }

            if (e.Key == Key.Right)
                if (!(X_Direction == -1))
                {
                    X_Direction = 1;
                    Y_Direction = 0;
                }

            if (e.Key == Key.Up)
                if (!(Y_Direction == 1))
                {
                    X_Direction = 0;
                    Y_Direction = -1;
                }

            if (e.Key == Key.Down)
                if (!(Y_Direction == -1))
                {
                    X_Direction = 0;
                    Y_Direction = 1;
                }
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void buttonMemu_Click(object sender, RoutedEventArgs e)
        {
            time.Stop();
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }
        private void buttonTryAgain_Click(object sender, RoutedEventArgs e)
        {
            time.Stop();
            SnakeGame wintry = new SnakeGame();
            wintry.Show();
            this.Close();
        }
    }
}

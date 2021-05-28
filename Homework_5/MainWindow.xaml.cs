

//UWNetID: chrisd94
//Name: Christopher Davenport
//Class: CSHP320 A sp 21: Creating Client Applications using .Net Core
//Homework 4

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion

        #region Private Members

        private DisplayIcon[] outcome;
        private bool Player1Turn;
        private bool gameOver;
        #endregion

        private void NewGame()
        {
            outcome = new DisplayIcon[9];
            for (var i = 0; i < outcome.Length; i++)
                outcome[i] = DisplayIcon.Empty;

            Player1Turn = true;

            uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
                gameOver = false;
            });

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            //var column = button.Tag;
                //var row = button.Tag;
            var index = column + (row * 3);

            if (outcome[index] != DisplayIcon.Empty)
                return;
            if (Player1Turn)
                outcome[index] = DisplayIcon.Cross;
            else
                outcome[index] = DisplayIcon.Zero;

            button.Content = Player1Turn ? "X" : "O";

            if (Player1Turn)
                button.Foreground = Brushes.Green;

            if (Player1Turn)
                Player1Turn = false;
            else
                Player1Turn = true;

            CheckForWin();
        }

        private void CheckForWin()
        {
            if (outcome[0] != DisplayIcon.Empty && (outcome[0] & outcome[1] & outcome[2]) == outcome[0])
            {
                gameOver = true;

            }

            if (!outcome.Any(outcome => outcome == DisplayIcon.Empty))
            {
                gameOver = true;
                uxGrid.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Red;

                });

            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }
    }
}

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


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool turn = true;
        int turn_count = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            turn = true;
            turn_count = 0;
            UIElementCollection myButtons = uxGrid.Children;
            foreach (var btn in myButtons)
            {
                Button b = (Button)btn;
                b.IsEnabled = true;
                b.Content = "";
                uxTurn.Text = "";
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int col = Grid.GetColumn(b);
            int row = Grid.GetRow(b);
               

            if (turn)
            {
                b.Content = "X";
              
            }
            else
            {
                b.Content = "O";
            }
            turn = !turn;
            b.IsEnabled = false;
            turn_count++;
            CheckForWinner(col, row);

        }

        private void CheckForWinner(int col, int row)
        {
            //Wasn't sure how to use the col,row coordinates to extract the items Content so I did the below.
            //How can the coordinates from the Tag be used to compare? 
            bool WinnerFound = false;
            UIElementCollection myButtons = uxGrid.Children;
            Button btnOne = (Button) myButtons[0];
            Button btnTwo = (Button)myButtons[1];
            Button btnThree = (Button)myButtons[2];
            Button btnFour = (Button)myButtons[3];
            Button btnFive = (Button)myButtons[4];
            Button btnSix = (Button)myButtons[5];
            Button btnSeven = (Button)myButtons[6];
            Button btnEight = (Button)myButtons[7];
            Button btnNine = (Button)myButtons[8];

            if (btnOne.Content == btnTwo.Content && btnTwo.Content == btnThree.Content && !btnOne.IsEnabled)
            {
                WinnerFound = true;
            }

            else if (btnThree.Content == btnFour.Content && btnFour.Content == btnFive.Content && !btnThree.IsEnabled)
            {
                WinnerFound = true;
            }
            else if (btnSix.Content == btnSeven.Content && btnSeven.Content == btnEight.Content && !btnSix.IsEnabled)
            {
                WinnerFound = true;
            }

              else if (btnOne.Content == btnFour.Content && btnFour.Content == btnSeven.Content && !btnOne.IsEnabled)
            {
                WinnerFound = true;
            }

            else if (btnTwo.Content == btnFive.Content && btnFive.Content == btnEight.Content && !btnTwo.IsEnabled)
            {
                WinnerFound = true;
            }

            else if (btnThree.Content == btnSix.Content && btnSix.Content == btnNine.Content && !btnThree.IsEnabled)
            {
                WinnerFound = true;
            }

            else if (btnOne.Content == btnFive.Content && btnFive.Content == btnNine.Content && !btnOne.IsEnabled)
            {
                WinnerFound = true;
            }

            else if (btnThree.Content == btnFive.Content && btnFive.Content == btnSeven.Content && !btnThree.IsEnabled)
            {
                WinnerFound = true;
            }

            if (WinnerFound)
            {
                disableButtons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                uxTurn.Text = $"{winner} wins!";
                
            }   
            else
            {
                if (turn_count==9)
                {
                    uxTurn.Text = "It's a draw!";
                }
            }
        }
        private void disableButtons()
        {
            UIElementCollection myButtons = uxGrid.Children;
            foreach (var btn in myButtons)
            {
                Button b = (Button)btn;
                b.IsEnabled = false;
            }

        }
    }
}

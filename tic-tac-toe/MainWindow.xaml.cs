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

namespace tic_tac_toe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private Logic logic;
        private int xWins, oWins;

        private Button[] buttons;

		public MainWindow()
		{
			InitializeComponent();
            buttons = new Button[] { button0, button1, button2, button3, button4, button5, button6, button7, button8 };
            start_game();
		}

        private void start_game()
        {
            logic = new Logic();
            logic.OnGameEnd += game_victory;

            foreach (Button b in buttons)
                b.Content = "";
            PlayerTurn.Content = "X";
            PlayerTurn.Foreground = Brushes.Red;

            turnLabel.Content = "Player Turn:";
            PlayerTurn.Visibility = System.Windows.Visibility.Visible;
        }

        private void game_victory(Logic l, PlayerValue who)
        {
            if (who == PlayerValue.Circle)
            {
                turnLabel.Content = "Circles win!";
                oWins++;
            }
            else if (who == PlayerValue.Cross)
            {
                turnLabel.Content = "Crosses win!";
                xWins++;
            }
            else
            {
                turnLabel.Content = "Draw";
            }
            
            PlayerTurn.Visibility = System.Windows.Visibility.Hidden;

            scoreX.Content = xWins.ToString();
            scoreO.Content = oWins.ToString();
        }

        private void button_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            if (!sender.GetType().IsSubclassOf(typeof(Control)))
                return;

            Control button = (Control)sender;

            if (button.Tag == null || button.Tag.GetType() != typeof(string))
                return;

            int number;
            if (!int.TryParse(button.Tag.ToString(), out number))
                return;

            if (number < 0 || number > 8)
                return;

            button_click(button, number);
        }

        private void button_click(Control button, int number)
        {
            PlayerValue currentPlayer = logic.nextPlayer;

            if (logic.ChangeState(number))
                change_button(button, currentPlayer);
        }

        private void change_button(Control control, PlayerValue player)
        {
            if (control.GetType() != typeof(Button))
                return;

            Button button = (Button)control;

            if (player == PlayerValue.Circle)
            {
                button.Foreground = Brushes.Blue;
                button.Content = "O";
                PlayerTurn.Foreground = Brushes.Red;
                PlayerTurn.Content = "X";
            }
            else if (player == PlayerValue.Cross)
            {
                button.Foreground = Brushes.Red;
                button.Content = "X";
                PlayerTurn.Foreground = Brushes.Blue;
                PlayerTurn.Content = "O";
            }
            else
            {
                button.Content = "";
            }
        }

        private void gameButton_Click(object sender, RoutedEventArgs e)
        {
            start_game();
        }
	}
}

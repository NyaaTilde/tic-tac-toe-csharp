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

		public MainWindow()
		{
			InitializeComponent();
            start_game();
		}

        private void start_game()
        {
            logic = new Logic();
            button0.Content = "";
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
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
            }
            else if (player == PlayerValue.Cross)
            {
                button.Foreground = Brushes.Red;
                button.Content = "X";
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

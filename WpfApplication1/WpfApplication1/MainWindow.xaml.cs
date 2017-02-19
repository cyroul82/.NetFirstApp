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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly String HIDE_BUTTON_TEXT = "Hide";
        private readonly String RESET_BUTTON_TEXT = "Reset";
        private HiddenWordClass hiddenWordClass;
        private Int32 MIN_WORD_LENGTH = 4;
        private readonly Int32 MAX_CHANCES = 5;
        private Int32 chanceCount;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void hideButton_Click(object sender, RoutedEventArgs e)
        {
            if ((String)hideButton.Content == HIDE_BUTTON_TEXT)
            {
                String s = hiddenWordTextBox.Text;
                if (s.Length <= MIN_WORD_LENGTH)
                {
                    MessageBox.Show("Please enter more 4 letters !", "Error letters Numbers", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else {
                    start();
                    return;
                }
            }

            if ((String)hideButton.Content == RESET_BUTTON_TEXT)
            {
                reset();
                return;
            }
        }

        private void reset()
        {
            hiddenWordClass.reset();

            //Clear the textbox and disable it
            hiddenWordTextBox.Clear();
            hiddenWordTextBox.IsEnabled = true;

            letterTextBox.Clear();

            chanceLabel.Content = "";

            chanceCount = MAX_CHANCES;
            hideControl();

            //Set the button context to Hide
            hideButton.Content = HIDE_BUTTON_TEXT;
        }

        private void start()
        {
            hiddenWordClass = new HiddenWordClass(hiddenWordTextBox.Text);

            chanceCount = MAX_CHANCES;

            chanceLabel.Content = chanceCount;

            //Clear the textbox and disable it
            hiddenWordTextBox.Clear();
            hiddenWordTextBox.Text = hiddenWordClass.hideWord();
            hiddenWordTextBox.IsEnabled = false;

            showControl();

            //Set the button context to Reset
            hideButton.Content = RESET_BUTTON_TEXT;
        }

        private void showControl()
        {
            okButton.Visibility = Visibility.Visible;
            letterTextBox.Visibility = Visibility.Visible;
            chanceLabel.Visibility = Visibility.Visible;
            chanceLabelText.Visibility = Visibility.Visible;
        }

        private void hideControl()
        {
            okButton.Visibility = Visibility.Hidden;
            letterTextBox.Visibility = Visibility.Hidden;
            chanceLabel.Visibility = Visibility.Hidden;
            chanceLabelText.Visibility = Visibility.Hidden;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            if (letterTextBox.Text.Length != 0) {
                String s = letterTextBox.Text;
                char c = s[0];
                if (hiddenWordClass.isLetterPresent(c))
                {
                    hiddenWordTextBox.Clear();
                    hiddenWordTextBox.Text = hiddenWordClass.HiddenWord;
                }
                else
                {
                    chanceCount--;
                    chanceLabel.Content = chanceCount;
                    if(chanceCount == 0)
                    {
                        gameOver();
                    }
                }

                letterTextBox.Clear();

                if (hiddenWordClass.isFinish())
                {
                    gameFinish();
                }
            }
        }

        private void gameFinish()
        {
            MessageBox.Show("Well Done !\nYou Won", "Finished", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            reset();

        }

        private void gameOver()
        {
            MessageBox.Show("Game Over :( !\n The word was : " + hiddenWordClass.Word
                , "Game Over", MessageBoxButton.OK, MessageBoxImage.Warning);
            reset();
        }

    }
}

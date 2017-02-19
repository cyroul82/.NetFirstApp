using System;
using System.Windows;
using System.Windows.Input;
using System.Drawing;
using System.Text.RegularExpressions;

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
        private Regex myRegex = new Regex("[a-zA-Z]");

        public MainWindow()
        {
            InitializeComponent();
            maxChanceTextBox.Text = MAX_CHANCES.ToString();
            hiddenWordTextBox.Focus();

        }

        private void hideButton_Click(object sender, RoutedEventArgs e)
        {
            if ((String)hideButton.Content == HIDE_BUTTON_TEXT)
            {
                String s = hiddenWordTextBox.Text;
                if (myRegex.IsMatch(s))
                {
                    if (s.Length == 0)
                    {
                        MessageBox.Show("If you don't enter a word,\nhow do you want to play ?!!", "Error Word", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (s.Length <= MIN_WORD_LENGTH)
                    {
                        MessageBox.Show("Please enter more than 4 characters !", "Error Size", MessageBoxButton.OK, MessageBoxImage.Error);
                        hiddenWordTextBox.Focus();
                        return;
                    }
                    else
                    {
                        start();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid word, with only letter between a and z !!!", "Error Letter", MessageBoxButton.OK, MessageBoxImage.Error);
                    reset();
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
            if(hiddenWordClass != null)
            {
                hiddenWordClass.reset();
            }
            

            //Clear the textbox and disable it
            hiddenWordTextBox.Clear();
            hiddenWordTextBox.IsEnabled = true;
            hiddenWordTextBox.Focus();

            letterTextBox.Clear();

            chanceLabel.Content = "";

            chanceCount = MAX_CHANCES;
            hideControl();

            //Set the button context to Hide
            hideButton.Content = HIDE_BUTTON_TEXT;
        }

        private void start()
        {
            hiddenWordClass = new HiddenWordClass(hiddenWordTextBox.Text.ToUpper());

            chanceCount = MAX_CHANCES;

            chanceLabel.Content = chanceCount;

            //Clear the textbox and disable it
            hiddenWordTextBox.Clear();
            hiddenWordTextBox.Text = hiddenWordClass.hideWord();
            hiddenWordTextBox.IsEnabled = false;

            showControl();
            letterTextBox.Focus();

            //Set the button context to Reset
            hideButton.Content = RESET_BUTTON_TEXT;
        }

        private void showControl()
        {
            searchStackPanel.Visibility = Visibility.Visible;
            chanceStackPanel.Visibility = Visibility.Visible;
            labelTopText.Visibility = Visibility.Hidden;
        }

        private void hideControl()
        {
            searchStackPanel.Visibility = Visibility.Hidden;
            chanceStackPanel.Visibility = Visibility.Hidden;
            labelTopText.Visibility = Visibility.Visible;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            if (letterTextBox.Text.Length != 0)
            {
                if (myRegex.IsMatch(letterTextBox.Text))
                {
                    String s = letterTextBox.Text.ToUpper();
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
                        switch (chanceCount)
                        {
                            case 0:
                                gameFinish();
                                break;
                            case 1:
                                chanceLabelText.Content = "Last Chance !";
                                chanceLabelText.Foreground = System.Windows.Media.Brushes.Red;
                                chanceLabel.Visibility = Visibility.Collapsed;
                                break;

                        }

                    }

                    letterTextBox.Clear();
                    letterTextBox.Focus();

                    if (hiddenWordClass.isFinish())
                    {
                        gameFinish();
                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid letter, between a and z !!!", "Error Letter", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
            }
        }

        private void gameFinish()
        {
            if (chanceCount == MAX_CHANCES)
            {
                MessageBox.Show("Perfect no mistakes Bravo :) !\n You Won", "Finished", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (chanceCount == 1)
            {
                MessageBox.Show("You Won in extremis !!! :)", "Finished", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Well Done !\nYou Won", "Finished", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            reset();

        }

        private void gameOver()
        {
            MessageBox.Show("Game Over :( !\n The word was : " + hiddenWordClass.Word
                , "Game Over", MessageBoxButton.OK, MessageBoxImage.Warning);
            reset();
        }

        private void hiddenWordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                hideButton_Click(this, new RoutedEventArgs());
            }
        }

        private void letterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                okButton_Click(this, new RoutedEventArgs());
            }

        }
    }
}


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

        private String hiddenWord;
        private Int32 hiddenWordLength;
        public static readonly String hideButtonText = "Hide";
        public static readonly String resetButtonText = "Reset";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void hideButton_Click(object sender, RoutedEventArgs e)
        {
            if ((String)hideButton.Content == hideButtonText)
            {
                //set the hidden word and its length
                hiddenWord = hiddenWordTextBox.Text;
                hiddenWordLength = hiddenWord.Length;

                //Clear the textbox and disable it
                hiddenWordTextBox.Clear();
                hiddenWordTextBox.IsEnabled = false;
                
                //Set the button context to Reset
                hideButton.Content = resetButtonText;
                return;
            }

            if ((String)hideButton.Content == resetButtonText)
            {
                //set the hidden word and its length
                hiddenWord = null;
                hiddenWordLength = 0;

                //Clear the textbox and disable it
                hiddenWordTextBox.Clear();
                hiddenWordTextBox.IsEnabled = true;

                //Set the button context to Hide
                hideButton.Content = hideButtonText;
                return;

            }



        }
    }
}

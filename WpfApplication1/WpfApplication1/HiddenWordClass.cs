using System;
using System.Text;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction for MainWindow.xaml.cs
    /// </summary>
    /// 
    class HiddenWordClass
    {
        private String word;
        private Int32 wordLength;
        private String hiddenWord;

        public HiddenWordClass(String word)
        {
            Word = word;
        }

        //Check whether the letter is in the word to find or already found
        public bool isLetterPresent (char c)
        {
            bool b = false;
            
            StringBuilder stringBuilder = new StringBuilder(HiddenWord);

            for (int i=0; i<wordLength; i++)
            {
                if (Word[i] == c && HiddenWord[i] != c)
                {
                    stringBuilder[i] = c;
                    b = true;
                }
            }

            HiddenWord = stringBuilder.ToString();
            
            //Return true if letter is in the word
            return b;
        }

        //Check whether the word has been completely found
        public bool isFinish()
        {
            if (Word == HiddenWord) return true;
            else return false;
        }

        //Hide the word and return the String hiddenWord with * to display
        public String hideWord()
        {
            if (Word != null)
            {
                wordLength = Word.Length;
                for (int i=0; i<wordLength; i++)
                {
                    HiddenWord += "*";
                }
                return HiddenWord;
            }
            else return null;
            
        }

        //Reset the word to null
        public void reset()
        {
            Word = null;
        }


        public string HiddenWord
        {
            get
            {
                return hiddenWord;
            }

            set
            {
                hiddenWord = value;
            }
        }

        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
            }
        }
    }
}

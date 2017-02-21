using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailAdresse
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag;

            do
            {
                Console.WriteLine("Enter your email @");
                String email = Console.ReadLine();

                //convert to lowercase
                email = email.ToLower();

                //check if the email contains the @ symbol
                if (isThereOnlyOneAt(email))
                { 
                    //get the postion in the string of the @
                    int atPostion = email.IndexOf('@');

                    //put the first part in a string 
                    String firstPartEmail = email.Substring(0, atPostion);
                    //put the second part in a string
                    String secondPartEmail = email.Substring(atPostion + 1, email.Length - firstPartEmail.Length - 1);

                    if (isStringOk(firstPartEmail) && isStringOk(secondPartEmail))
                    {
                        Console.WriteLine("Your email is right : {0}", email);
                    }
                }
                
                Console.WriteLine("Again (y/n)");
                String s = Console.ReadLine();
                s.ToLower();
                flag = (s == "y") ? true : false;
            }
            while (true);
        }

        private static void ErrorMessage(String message)
        {
            Console.WriteLine("Please enter a valid @mail ! : " + message);
        }

        private static bool isThereOnlyOneAt(String email)
        {
            bool flag = false;
            int count = 0;
            for(int i=0; i<email.Length; i++)
            {
                if (email[i] == '@') { count++; }   
            }

            if(count == 1)
            {
                flag = true;
               
            }
            else {
                flag = false;
                ErrorMessage("You can have only one @ !!!");
            }

            return flag;
        }

        private static bool isStringOk(String s)
        {
            bool flag = true;
            if (!Char.IsLetterOrDigit(s[s.Length-1]))
            {
                ErrorMessage("Your email contains an error ! with a dot at the end !!!");
                flag = false;
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(
                            (s[i] >= 'a' && s[i] <= 'z')  
                            || s[i] == '.' 
                            || s[i] == '-' 
                            || s[i] == '_' 
                            || (s[i] >= 0 && s[i]<=9))
                        )  
                    {
                        flag = false;
                        ErrorMessage("Your email must use only [a-z0-9 . - _]");
                    }
                    if (s[i] == '.' && s[i + 1] == '.')
                    {
                        flag = false;
                        ErrorMessage("You can't have 2 dots in a row !!!");
                    }
                }
            }

            return flag;
        }
        
       


    }
}

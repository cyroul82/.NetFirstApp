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
                
                //check to see if the first character is [a-z0-9] and last [a-z]
                if (Char.IsLetterOrDigit(email[0]) && Char.IsLetter(email[email.Length-1]))
                {
                    //check if the email contains the @ symbol
                    if (isThereOnlyOneAt(email)) {
                        

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
                        else
                        {
                            ErrorMessage("Your email must use only [a-z0-9 . - _]");
                        }

                    }
                    else
                    {
                        ErrorMessage("Your email must have @ symbol and only one !");
                    }
                }
                else
                {
                    ErrorMessage("First character must be [a-z0-9] and last character must be [a-z]!");
                }

                Console.WriteLine("Again (y/n)");
                String s = Console.ReadLine();
                flag = (s == "y") ? true : false;
            }
            while (flag);
        

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
            }

            return flag;
        }

        private static bool isStringOk(String s)
        {
            bool flag = true;
            for (int i=0; i<s.Length; i++)
            {
                if (!(Char.IsLetterOrDigit(s[i]) || s[i]=='.' || s[i]=='-' || s[i]=='_'))
                {
                    flag = false;
                }
                if(s[i] == '.' && s[i+1] == '.')
                {
                    flag = false;
                }
            }

            return flag;
        }


    }
}

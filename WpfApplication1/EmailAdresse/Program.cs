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

                    if (isStringOk(firstPartEmail) && isSecondStringOk(secondPartEmail))
                    {
                        Console.WriteLine("Your email is right : {0}", email);
                    }
                }
                
                Console.WriteLine("Again (y/n)");
                String s = Console.ReadLine();
                s.ToLower();
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
                ErrorMessage("You can have only one @ !!!");
            }

            return flag;
        }

        private static bool isStringOk(String s)
        {
            
            bool flag = true;
            int minLength = 3;
            //To check the size of the string

            if (!(s.Length < minLength))
            {
                if (!isCharOk(s))
                {
                    flag = false;
                }
                
            }
            else
            {
                flag = false;
                ErrorMessage("The First part of your email must have at least : " + minLength + " characters !");
            }

            return flag;
        }

        private static Boolean isSecondStringOk(String s)
        {
            Boolean flag = true;
            int minLength = 4;

            if (!(s.Length < minLength))
            {
                if (!isCharOk(s))
                {
                    flag = false;
                }
                if (!isDomainNameOk(s))
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
                ErrorMessage("The Second part of your email must have at least : " + minLength + "characters !");
            }
                return flag;
        }


        //make sure that the string contain only godd character !!!
        private static Boolean isCharOk(String s)
        {
            Boolean flag = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (!(
                        (s[i] >= 'a' && s[i] <= 'z')
                        || s[i] == '.'
                        || s[i] == '-'
                        || s[i] == '_'
                        || (s[i] >= 0 && s[i] <= 9))
                    )
                {
                    flag = false;
                    ErrorMessage("Your email must use only [a-z0-9 . - _]");
                }
                if (s.Contains(".."))
                {
                    flag = false;
                    ErrorMessage("You can't have 2 dots in a row !!!");
                }
            }
            return flag;
        }

        private static Boolean isDomainNameOk (String s)
        {
            Boolean flag = true;
            if (!s.Contains('.'))
            {
                flag = false;
                ErrorMessage("You must have at least one dot in your Domain Name");
            }
            else
            {
                int lastDotPostion = 0;
                for (int i = s.Length-1; i >= 0; i--)
                {
                    if (s[i] == '.')
                    {
                        lastDotPostion = i;
                        break;
                    }
                }

                String domain = s.Substring(0, lastDotPostion);
                String endDomain = s.Substring(lastDotPostion+1, (s.Length-1)-domain.Length);
                
                if(endDomain.Length < 2)
                {
                    flag = false;
                    ErrorMessage("Error in your domain name, missing a letter ???");
                }
            }

            return flag;
        }
        
       


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAge
{
    class SiAge
    {
        
        static void Main(string[] args)
        {
            Int32 age;
            String message = null;

            Console.WriteLine("How old are you : ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 18)
                {
                    message = "Not for you !, you're not 18 years old !";
                }
                else if (age < 26)
                {
                    message = "Yound Status";
                }
                else if (age < 65)
                {
                    message = "Adult Status";
                }
                else
                {
                    message = "For retired !";
                }

                Console.WriteLine(message);
                Console.ReadLine();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Format Exception, Please enter an age valid");
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("OverFlow Exception : " + oe);
                Console.ReadLine();
            }
            


            

  
        



        }
    }
}

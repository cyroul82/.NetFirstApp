using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypo
{
    class Hypo
    {
        static void Main(string[] args)
        {
            Double firstSide;
            Double secondSide;
            Double hypothenus;

            Console.Write("Length of the first side  : ");
            String s = Console.ReadLine();

            while (!Double.TryParse(s, out firstSide))
            {
                Console.WriteLine("the value isn't a double ");
                Console.Write("Please enter a new number : ");
                s = Console.ReadLine();
            }

            Console.Write("Length of the Second side  : ");
            String s1 = Console.ReadLine();

            while (!Double.TryParse(s1, out secondSide))
            {
                Console.WriteLine("the value isn't a double ");
                Console.Write("Please enter a new number : ");
                s1 = Console.ReadLine();
            }
        

            hypothenus = Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2));

            Console.WriteLine("Hypothenus = " + hypothenus);

            Console.ReadLine();
        
        }
    }
}

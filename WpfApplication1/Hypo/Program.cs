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
            Boolean flag = true;
            while (flag)
            {
                Console.Write("Length of the first side  : ");
                String s = Console.ReadLine();
                Double firstSide = getDouble(s);

                Console.Write("Length of the Second side  : ");
                s = Console.ReadLine();
                Double secondSide = getDouble(s);

                Console.WriteLine("Hypothenus = " + getHypothenus(firstSide, secondSide));

                Console.WriteLine("Another Calcul :(y/n)");
                String yesOrNo = Console.ReadLine();
                yesOrNo.ToLower();
                flag = (yesOrNo == "y") ? true : false;
            }
     
        }

        //Convert a string in Double, wait until true !
        private static Double getDouble(String s)
        {
            Double d;
            while (!Double.TryParse(s, out d))
            {
                Console.WriteLine("the value isn't a double ");
                Console.Write("Please enter a new number : ");
                s = Console.ReadLine();
            }
            return d;
        }

        private static Double getHypothenus(Double firstSide, Double secondSide)
        {
            return Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2));
        }
    }
}

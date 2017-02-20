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

            Console.Write("Length of the first wide  : ");
            firstSide  = Convert.ToDouble(Console.ReadLine());
            Console.Write("Length of the second side : ");
            secondSide = Convert.ToDouble(Console.ReadLine());

            hypothenus = Math.Sqrt(Math.Pow(firstSide, 2) + Math.Pow(secondSide, 2));

            Console.WriteLine("Hypothenus = " + hypothenus);
            Console.ReadLine();
        
        }
    }
}

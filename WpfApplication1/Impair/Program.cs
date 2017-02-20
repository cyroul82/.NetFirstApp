using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impair
{
    class Impair
    {
        static void Main(string[] args)
        {
            Int32 c;

            c = 0;
            Console.WriteLine("Affiche les premiers nombres impairs");
            for (int i=1; i<20; i++)
            {
                if(i%2 != 0)
                {
                    c++;
                    Console.WriteLine("{0} est le {1}ème nombre impair", i, c);
                }
            }
            Console.ReadLine();
        }
    }
}

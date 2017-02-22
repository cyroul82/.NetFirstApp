using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NombrePremier
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] diviseurs = { 2, 3, 5, 7 };
            int i = 1000000, j;
            while (i < 2000000)
            {
                for (j = 0; j <= 3; j++)
                {
                    if (i % diviseurs[j] == 0)
                    {
                        break;
                    }
                    if (j == 3)
                    {
                        Console.WriteLine(i + " est premier");
                    }
                }
                i++;
            }

            Console.ReadLine();
        }

    }
}

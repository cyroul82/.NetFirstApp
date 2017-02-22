using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean flag = true;
            while (flag) {
                Int32[] intArray = new Int32[5];
                Int32 maxi = 0;
                int index = 0;
                Console.WriteLine("Recherche de Maximus");

                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write("Entrez un nombre entier : ");
                    intArray[i] = convertToInt(Console.ReadLine()); ;
                    if (intArray[i] > maxi)
                    {
                        maxi = intArray[i];
                        index = i;
                    }
                }

                Console.WriteLine("Le plus grand nombre saisi est {0} \n c'est l'entrée {1}", maxi, index + 1);

                Console.WriteLine("Refaire? : (o/n)");
                String yesOrNo = Console.ReadLine();
                yesOrNo.ToLower();
                flag = (yesOrNo == "o") ? true : false;
            }

        }

        private static Int32 getMaxFromIntTab(Int32[] tab)
        {
            Int32 maxi = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = convertToInt(Console.ReadLine()); ;
                if (tab[i] > maxi)
                {
                    maxi = tab[i];
                }
            }
            return maxi;
        }

        

        private static Int32 convertToInt(String s)
        {
            Int32 n;
            while (!Int32.TryParse(s, out n))
            {
                Console.WriteLine("ce nombre n'est pas entier !");
                Console.Write("Entrez un nombre entier : ");
                s = Console.ReadLine();
            }

            return n;

        }
    }
}

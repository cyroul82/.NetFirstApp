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

            Console.Write("Jusqu'a combien voulez compter les nombres premiers : ");

            try
            {
                int max = Convert.ToInt32(Console.ReadLine());
                int Nombre = 3;
                while (Nombre <= max)
                {

                    bool b2 = false;
                    for (int i = 2; i <= Nombre - 1; i++)
                    {

                        if (Nombre % i == 0)
                        {
                            b2 = true;
                        }
                    }
                    if (!b2)
                    {
                        Console.WriteLine("{0} est nombre premier ", Nombre);
                    }

                    Nombre++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Votre valeur n'est pas un entier ");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Votre valeur dépasse Int32");
            }

            Console.ReadLine();
        }

    }
}

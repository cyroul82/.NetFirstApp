using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factor
{
    class Program
    {
        static void Main(string[] args)
        {
            String cRep;
            Int32 nFactor;
            Int32 nNombre;

            cRep = "o";
            while(cRep == "o" || cRep == "O")
            {
                nFactor = 1;
                Console.WriteLine("Calcul de factorielle");
                Console.Write("Entrez un nombre: ");
                try
                {
                    nNombre = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= nNombre; i++)
                    {

                        nFactor = nFactor * i;
                    }
                    Console.WriteLine("La factorielle de {0} est donc : {1}", nNombre, nFactor);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur type can't convert !!! \n");
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine("OverFlow Error : " + oe);
                }
                
                
                finally
                {
                    Console.WriteLine("Voulez-vous remcommence (o/n)");
                    cRep = Console.ReadLine();
                }

                
            }

            Console.WriteLine("Bye bye");
        }
    }
}

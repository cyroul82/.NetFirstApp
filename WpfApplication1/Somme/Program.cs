using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somme
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 iNombre = 0;
            Int32 iMin = 2147483647;
            Int32 iMax = 0;
            Int32 iCpt = 0;
            Int32 iSomme = 0;

            Console.WriteLine("Calculs Statistiques");

            iNombre = 1;

            while (iNombre != 0)
            {
                Console.WriteLine("Entrez un Nombre (0 pour sortir)");
                iNombre = Convert.ToInt32(Console.ReadLine());

                if(iNombre != 0)
                {
                    iCpt++;
                    iSomme += iNombre;

                    if(iNombre < iMin)
                    {
                        iMin = iNombre;
                    }

                    if(iNombre > iMax)
                    {
                        iMax = iNombre;
                    }
                }
            }

            if(iCpt > 0)
            {
                Console.WriteLine("Statistiques sur les nombres saisis : {0} nombres saisis \n " +
                    "Compris entre {1} et {2} pour une somme de {3} \n Et une moyenne de {4}", iCpt, iMin, iMax, iSomme, iSomme/iCpt);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Revenez quand vous voulez...");
                Console.ReadLine();
            }
            


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu_AFPA
{
    class Program
    {
        static void Main(string[] args)
        {
            String strMotCache;
            String strMotTrouve;
            String strLettreSaisie;
            Int32 iLgMotCache;
            Int32 iNbVies;
            Boolean bTrouve;
            Boolean bLettreOK;
            Int32 iNbEssais;
            Int32 iNbLettresOK;

            Console.WriteLine("Jeu du Pendu");
            Console.WriteLine("Entrez le mot caché");
            strMotCache = Console.ReadLine();

            //Clear the screen
            for (int i=0; i<24; i++)
            {
                Console.WriteLine(" ");
            }

            //initialisations, calcul nb vies et concat mot découvert
            strMotTrouve = "";
            iNbLettresOK = 0;
            iLgMotCache = strMotCache.Length;
            iNbVies = iLgMotCache * 2;

            Console.WriteLine("Vous avez droit à {0} essais.", iNbVies);

            for (int i=0; i < iLgMotCache; i++)
            {
                strMotTrouve = strMotTrouve + "*";
            }   

            Console.WriteLine("Mot Découvert {0}", strMotTrouve);

            bTrouve = false;
            iNbEssais = 0;

            while (!bTrouve && iNbEssais <= iNbVies)
            {
                Console.Write("Entree une lettre : ");
                strLettreSaisie = Console.ReadLine();

                bLettreOK = false;

                for(int i=0; i<= iLgMotCache-1; i++)
                {
                    if(strMotCache.Substring(i,1) == strLettreSaisie.Substring(0, 1))
                    {
                        bLettreOK = true;
                        iNbLettresOK++;

                        strMotTrouve = strMotTrouve.Substring(0, i) + strLettreSaisie.Substring(0, 1) + strMotTrouve.Substring(i + 1, iLgMotCache - 1 - i);
                    }
                }

                //Afficer succès / echec
                if (bLettreOK)
                {
                    Console.WriteLine("Super ! Continuez");
                }
                else
                {
                    Console.WriteLine("Dommage.. Continuez quand même...");
                }

                //compter l'essai
                iNbEssais++;

                Console.WriteLine("Vous en êtes à {0}", strMotTrouve);

                //mot trouvé ?
                if (strMotCache == strMotTrouve){
                    bTrouve = true;
                }
            }

            if (!bTrouve)
            {
                Console.WriteLine("Perdu ! le mot était {0}\nVous avez déjà trouvé {1} bonnes lettres\nVous ferez mieux la prochaine fois", strMotCache, iNbLettresOK);
            }
            else
            {
                Console.WriteLine("Bravo ! vous avez gagné en {0} essais !!", iNbEssais);
            }

            Console.ReadLine();
        }
    }
}

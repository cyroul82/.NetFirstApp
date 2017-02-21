using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi
{
    class Program
    {
        static void Main(string[] args)
        {
            int noteDo = 262;
            int noteRe = 294;
            int noteMi = 330;
            int noire = 400;
            int blanche = 800;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            centerText("Tables de Multiplication");

            for (int iTable = 1; iTable <= 10; iTable++)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                centerText("Tables des " + iTable);
                Console.ResetColor();
                for (int iNombre = 1; iNombre <= 10; iNombre++)
                {
                    Console.WriteLine("{0} x {1} = {2}", iNombre, iTable, iNombre*iTable);
                }

                centerText("--------------");

                Console.ReadKey(true);
            }

            //Au clair de la lune
            Console.Beep(noteDo, noire);
            Console.Beep(noteDo, noire);
            Console.Beep(noteDo, noire);
            Console.Beep(noteRe, noire);
            Console.Beep(noteMi, blanche);
            Console.Beep(noteRe, blanche);
            Console.Beep(noteDo, noire);
            Console.Beep(noteMi, noire);
            Console.Beep(noteRe, noire);
            Console.Beep(noteRe, noire);
            Console.Beep(noteDo, noire);
        }

        private static void centerText(String text)
        {
            int space = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(space, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}

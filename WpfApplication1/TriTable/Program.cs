using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace TriTable
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Int32[] array = new Int32[] { 25, 65, 48, 21, 69 };
            array = sortArray(array);
            //print result;
            for(int i=0; i<array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();

            Maxi.Program.getMaxFromIntTab(array);
            
        }

        private static Int32[] sortArray(Int32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = i+1 ; j <array.Length; j++)
                {
                    if(array[i] > array[j]) {
                        int a = array[i];
                        array[i] = array[j];
                        array[j] = a;
                    }
                }
            }
            return array;
        }

    }
}

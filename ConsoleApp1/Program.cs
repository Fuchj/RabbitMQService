using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] str= { 1, 2,3, 4 };
            int[] str1 = { 2, 3 };
            //List<bool> str2 = new List<bool>(); ;
            bool[] str3 = { false, false, false, false };
            for (int i = 0; i < str.Length; i++)
            {
                if (str1.Contains(str[i]))
                {
                    str3[i] = true;
                }

            }
            var a=   str.ToList();
            var b = str3.ToList();
            for (int i = 0; i < str3.Length; i++)
            {
                Console.WriteLine(str3[i]);
            }
           
            Console.ReadKey();
        }
    }
}

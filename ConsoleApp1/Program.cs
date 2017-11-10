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
            //int[] str= { 1, 2,3, 4 };
            //int[] str1 = { 2, 3 };
            ////List<bool> str2 = new List<bool>(); ;
            //bool[] str3 = { false, false, false, false };
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str1.Contains(str[i]))
            //    {
            //        str3[i] = true;
            //    }

            //}
            //var a=   str.ToList();
            //var b = str3.ToList();
            //for (int i = 0; i < str3.Length; i++)
            //{
            //    Console.WriteLine(str3[i]);
            //}
            List<long> num1 = new List<long>()
            {
                101,
                201,
                301,
                401,
                501,
                601,
                701,
                801,
                901
            };
            List<long> num2= new List<long>()
            {
                101,
               
                301,
              
                501,
               
                701,
              
                901
            };
         var a=   FilterNUM(num1, num2);
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.ReadKey();
        }
      static  List<bool> FilterNUM(List<long> num1, List<long> num2)
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < num1.Count; i++)
            {
                if (num2.Contains(num1[i]))
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }
    }
}

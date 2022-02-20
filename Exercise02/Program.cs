using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter value to convert to words.");

            string val;
            val = Console.ReadLine();
            string words = ConvertNumberToWord(val);

            Console.WriteLine("=============================================================");

            Console.WriteLine(words);
            Console.ReadLine();
        }
        static string ConvertNumberToWord(string Value)
        {
           
            BigInteger number;

            if (!BigInteger.TryParse(Value, out number))
            {
               
                return "Invalid value.";
            }
          
           return number.Towards();
            
        }
    }
}

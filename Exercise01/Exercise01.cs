using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01
{
    public static class Exercise01
    {

        public static string Towards(this int value)
        {
            return NumberToWords(BigInteger.Parse(value.ToString()));
        }
        public static string Towards(this double value)
        {

            return NumberToWords(BigInteger.Parse(value.ToString()));
        }
        public static string Towards(this BigInteger value)
        {

            return NumberToWords(BigInteger.Parse(value.ToString()));
        }
        public static string Towards(this long value)
        {

            return NumberToWords(BigInteger.Parse(value.ToString()));
        }
        static BigInteger int_floor(BigInteger x)
        {
            BigInteger remainder;
            BigInteger truncate;
            truncate = x;        // rounds down if + x, up if negative x
            remainder = x - truncate;   // normally + for + x, - for - x
                                        //....Adjust down (toward -infinity) for negative x, negative remainder
            if (remainder < 0 && x < 0)
                return truncate - 1;
            else
                return truncate;
        }

        static string NumberToWords(BigInteger n)
        {
             
            string[] unitslist = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tenslist = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            string[] suffixslist = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "quattuordecillion", "quindecillion", "sexdecillion", "septdecillion", "octodecillion", "novemdecillion", "vigintillion" };
            string words = "";

            bool tens = false;

            if (n < 0)
            {
                words += "negative ";
                n *= Convert.ToUInt64(-1);
            }

            int power = (suffixslist.Length + 1) * 3;

            while (power > 3)
            {
                BigInteger pow = BigInteger.Pow(10, power);
                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumberToWords(n / pow) + " " + suffixslist[(power / 3) - 1] + ", ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumberToWords(n / pow) + " " + suffixslist[(power / 3) - 1];
                    }
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumberToWords(int_floor(n / 1000)) + " thousand, ";
                else words += NumberToWords(int_floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumberToWords(int_floor(n / 100)) + " hundred and";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tenslist[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";

                    words += (tens ? "-" + unitslist[(int)n - 1] : unitslist[(int)n - 1]);
                    n -= int_floor(n);
                }
            }

            return words;

        }

    }
}

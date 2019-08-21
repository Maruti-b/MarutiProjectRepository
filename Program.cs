using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConvertNumbersToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            Write("Enter integer : ");

            var input = ReadLine();

            if (int.TryParse(input, out number))
            {
                WriteLine("\n  {0}\n", NumberToText(number ));
            }

            ReadKey();
        }

        public static string NumberToText(int number)

        {

            if (number == 0) return "Zero";

            var num = new int[4];
            var first = GetFirstValidIndexValue(number, num);

            return AppendNumberToStringFormat(first, num);
        }

        private static string AppendNumberToStringFormat(int first,int[] num)
        {
            int u, h, t;
            var and = "and ";

            var words0 = new List<string> { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

            var words1 = new List<string> { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

            var words2 = new List<string> { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

            var words3 = new List<string> { "Thousand ", "Million ", "Billion " };

            StringBuilder sb = new StringBuilder();

            for (int i = first; i >= 0; i--)

            {

                if (num[i] == 0) continue;

                u = num[i] % 10;

                t = num[i] / 10;

                h = num[i] / 100;

                t = t - 10 * h;

                if (h > 0) sb.Append(words0[h] + "Hundred ");

                if (u > 0 || t > 0)

                {

                    if (h > 0 || i < first) sb.Append(and);

                    if (t == 0)

                        sb.Append(words0[u]);

                    else if (t == 1)

                        sb.Append(words1[u]);

                    else

                        sb.Append(words2[t - 2] + words0[u]);

                }

                if (i != 0) sb.Append(words3[i - 1]);

            }
            return sb.ToString().TrimEnd();
        }

        private static int GetFirstValidIndexValue(int number,int[] num)
        {
            var first = 0;
            
            num[0] = number % 1000;

            num[1] = number / 1000;

            num[2] = number / 1000000;

            num[1] = num[1] - 1000 * num[2];

            num[3] = number / 1000000000;

            num[2] = num[2] - 1000 * num[3];

            for (int i = 3; i > 0; i--)

            {

                if (num[i] != 0)

                {

                    first = i;

                    break;

                }

            }

            return first;
        }
    }

}
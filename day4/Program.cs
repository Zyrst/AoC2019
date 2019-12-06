using System;

namespace day4
{
    class Program
    {
        static bool IsCorrectFormatPart1(int check)
        {
            string s = check.ToString();
            bool hasdouble = false;

            for (int i = 1; i < s.Length; i++)
            {
                var thisDigit = int.Parse(s[i].ToString());
                var prevDigit = int.Parse(s[i - 1].ToString());
                if (prevDigit > thisDigit)
                    return false;

                if (prevDigit == thisDigit)
                {
                    hasdouble = true;
                }
            }

            return hasdouble;
        }

        static bool IsCorrectFormatPart2(int check)
        {
            string s = check.ToString();
            bool hasdouble = false;
            int countOfThis = 1;

            for (int i = 1; i < s.Length; i++)
            {
                var thisDigit = s[i];
                var prevDigit = s[i - 1];
                if (prevDigit > thisDigit)
                    return false;

                if (prevDigit == thisDigit)
                {
                    countOfThis++;
                }
                else
                {
                    if (countOfThis == 2)
                        hasdouble = true;
                    countOfThis = 1;
                }
            }

            if (countOfThis == 2)
                hasdouble = true;

            return hasdouble;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //234208-765869
            int correctFormat = 0;
            for (int i = 234208; i <= 765869; i++)
            {
                if (IsCorrectFormatPart1(i))
                    correctFormat++;
            }
            Console.WriteLine(correctFormat);
            correctFormat = 0;
            for (int i = 234208; i <= 765869; i++)
            {
                if (IsCorrectFormatPart2(i))
                    correctFormat++;
            }

            Console.WriteLine(correctFormat);

            Console.ReadLine();
        }
    }
}

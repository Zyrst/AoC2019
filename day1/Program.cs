using System;
using System.IO;
using System.Collections.Generic;
namespace adventofcode
{
    class Program
    {
        static double CalcConsumption(double val)
        {
            return Math.Floor(val / 3) - 2;
        }

        static void Day1_1(List<double> allVals)
        {
            double total = 0;

            foreach (var i in allVals)
            {
                total += CalcConsumption(i);
            }

            Console.WriteLine($"Total consumption day1_1 : {total}");
        }

        static void Day1_2(List<double> allVals)
        {
            double total = 0;
            foreach (var i in allVals)
            {
                double lastFuelConsumption = i;
                while (true)
                {
                    lastFuelConsumption = CalcConsumption(lastFuelConsumption);
                    if (lastFuelConsumption < 0)
                        lastFuelConsumption = 0;
                    total += lastFuelConsumption;
                    if (lastFuelConsumption == 0)
                        break;
                }
            }

            Console.WriteLine($"Total consumption day1_2 {total}");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("input.txt");
            List<double> allVals = new List<double>();

            foreach (var strDoub in allLines)
                allVals.Add(double.Parse(strDoub));

            Day1_1(allVals);
            Day1_2(allVals);
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace day2
{
    class Program
    {
        static int LoopTheOpCode(int[] intCodes)
        {
            int currentPos = 0;
            bool running = true;
            while (running)
            {
                int instruction = intCodes[currentPos];
                switch (instruction)
                {
                    case 1:
                        //Adds togheter the two next saves in third
                        int pos1 = intCodes[currentPos + 1];
                        int pos2 = intCodes[currentPos + 2];
                        int pos3 = intCodes[currentPos + 3];
                        intCodes[pos3] = intCodes[pos1] + intCodes[pos2];
                        break;
                    case 2:
                        pos1 = intCodes[currentPos + 1];
                        pos2 = intCodes[currentPos + 2];
                        pos3 = intCodes[currentPos + 3];
                        intCodes[pos3] = intCodes[pos1] * intCodes[pos2];
                        break;
                    case 99:
                        running = false;
                        break;
                    default:
                        running = false;
                        //Console.WriteLine("Done, we ded");
                        break;
                }
                currentPos += 4;

                if (currentPos > intCodes.Length)
                    running = false;
            }

            return intCodes[0];
        }

        static void Part1()
        {
            var intCodes = File.ReadAllText("input.txt").Split(',').Select(Int32.Parse).ToArray();

            Console.WriteLine(LoopTheOpCode(intCodes));

            Console.ReadKey();
        }

        static void Part2()
        {
            var intCodes = File.ReadAllText("input.txt").Split(',').Select(Int32.Parse).ToList();
            //List<int> intCodes = new List<int>();
            //foreach (var opCode in allOpCodes)
            //{
            //    intCodes.Add(int.Parse(opCode));
            //}

            
            for(int i= 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var workingSet = intCodes.Select(x => x).ToArray();
                    workingSet[1] = i;
                    workingSet[2] = j;
                    LoopTheOpCode(workingSet);
                    if(workingSet[0] == 19690720)
                    {
                        Console.WriteLine(100 * i + j);
                        break;
                    }
                }
            }

            //Console.WriteLine($"Codes found {intCodes[1]} and {intCodes[2]}");
            //Console.WriteLine(100 * intCodes[1] * intCodes[2]);
            Console.ReadLine();
                
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}

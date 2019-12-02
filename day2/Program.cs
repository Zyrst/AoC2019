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

            Console.WriteLine($"Part 1: {LoopTheOpCode(intCodes)}");
        }

        static void Part2()
        {
            var intCodes = File.ReadAllText("input.txt").Split(',').Select(Int32.Parse).ToList();

            for(int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var workingSet = intCodes.Select(x => x).ToArray();
                    workingSet[1] = noun;
                    workingSet[2] = verb;
                    LoopTheOpCode(workingSet);
                    if(workingSet[0] == 19690720)
                    {
                        Console.WriteLine($"Part 2: {100 * noun + verb}");
                        break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }
    }
}

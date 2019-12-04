using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace day3
{
    class Program
    {
        static Dictionary<(int, int), int> GetWire(string[] wire)
        {
            Dictionary<String, int> xaxis = new Dictionary<string, int>()
            {
                {"R", 1 },
                {"L", -1 },
                {"U", 0 },
                {"D", 0 }
            };
            Dictionary<String, int> yaxis = new Dictionary<string, int>()
            {
                {"R", 0 },
                {"L", 0 },
                {"U", 1 },
                {"D", -1 }
            };
            int x, y, len; x = y = len = 0;
            Dictionary<(int, int), int> calcWire = new Dictionary<(int, int), int>();
            foreach (var l in wire)
            {
                string dir = l[0].ToString();
                xaxis.TryGetValue(dir, out int xmod);
                yaxis.TryGetValue(dir, out int ymod);
                int length = int.Parse(l.Remove(0, 1));
                for(int i = 0; i < length; i++)
                {
                    x += xmod;
                    y += ymod;
                    calcWire.TryAdd((x, y), ++len);
                }
                
            }

            return calcWire;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var wireStr0 = lines[0].Split(',');
            var wireStr1 = lines[1].Split(',');

            var wire0 = GetWire(wireStr0);
            var wire1 = GetWire(wireStr1);

            var diff = wire0.Keys.Intersect(wire1.Keys).ToList();

            Console.WriteLine(diff.Min(x => Math.Abs(x.Item1) + Math.Abs(x.Item2)));
            Console.WriteLine(diff.Min(x => wire0[x] + wire1[x]));

            Console.ReadLine();
        }
    }
}

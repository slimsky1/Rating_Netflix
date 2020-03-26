using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Raiting_Netflix
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var reader = new StreamReader(@"F:\Programacion\Visual Studio C#\Repos\Raiting_Netflix\ratings.txt"))
            {
                Dictionary<string, int> dicRaiting = new Dictionary<string, int>();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    var values = line.Split(',');

                    int value;


                    if (!dicRaiting.TryGetValue(values[1], out value))
                    {
                        dicRaiting.Add(values[1], int.Parse(values[2]));
                    }
                    else
                    {
                        dicRaiting[values[1]] = dicRaiting[values[1]] + int.Parse(values[2]);
                    }
                    

                }

                var top10 = dicRaiting.OrderByDescending(pair => pair.Value).Take(10);

                Console.WriteLine("** Top 10 users reviewing movies:");

                foreach (KeyValuePair<string, int> valor in top10)
                {
                    Console.WriteLine("{0,-10}: {1,-20} ",valor.Key, valor.Value);
                }

            }
            }
        }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace ExerciseProposedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> candidate = new Dictionary<string, int>();

            string path = @"c:\temp\votes.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);

                        if (candidate.ContainsKey(name))
                            candidate[name] += votes;
                        else
                            candidate[name] = votes;
                    }
                }

                Console.WriteLine("Votes:");

                foreach (KeyValuePair<string, int> item in candidate)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

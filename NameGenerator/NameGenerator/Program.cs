using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add a basic menu system and while loop

            GeneratePlaceNames("input.txt");
            //GenerateTavernNames("prefixes.txt", "adjective.txt", "verb.txt", "suffixes.txt");
            Console.ReadLine();
        }

        private static void GeneratePlaceNames(string _inputFile)
        {
            Random random = new Random();
            List<string> elements;
            List<string> names;

            elements = new List<string>();

            elements = File.ReadAllLines(_inputFile).ToList();

            Console.WriteLine("Enter number of names required: ");
            int namesRequired = int.Parse(Console.ReadLine());

            names = new List<string>();
            string temp = "";
            for (int i = 0; i < namesRequired; i++)
            {
                temp = elements[random.Next(elements.Count)] + elements[random.Next(elements.Count)];
                while (random.Next(2) == 0)
                {
                    temp += elements[random.Next(elements.Count)];
                }
                char.ToUpper(temp[0]);
                names.Add(temp);
            }

            File.WriteAllLines("names.txt", names);
            Console.WriteLine("Done!");
        }


        private static void GenerateTavernNames(string _inputFilePrefixes, string _inputFileAdjectives, string _inputFileVerbs, string _inputFileSuffixes)
        {
            Random random = new Random();
            List<string> prefixes;
            List<string> adjectives;
            List<string> verbs;
            List<string> suffixes;
            List<string> names;

            prefixes = new List<string>();
            adjectives = new List<string>();
            verbs = new List<string>();
            suffixes = new List<string>();

            prefixes = File.ReadAllLines(_inputFilePrefixes).ToList();
            adjectives = File.ReadAllLines(_inputFileAdjectives).ToList();
            verbs = File.ReadAllLines(_inputFileVerbs).ToList();
            suffixes = File.ReadAllLines(_inputFileSuffixes).ToList();

            Console.WriteLine("Enter number of tavern names required: ");
            int namesRequired = int.Parse(Console.ReadLine());

            names = new List<string>();
            string temp = "";
            for (int i = 0; i < namesRequired; i++)
            {
                if (random.Next(2) == 0)
                {
                    temp = prefixes[random.Next(prefixes.Count)] + adjectives[random.Next(adjectives.Count)] + verbs[random.Next(verbs.Count)];
                }
                else
                {
                    temp = adjectives[random.Next(adjectives.Count)] + verbs[random.Next(verbs.Count)] + suffixes[random.Next(suffixes.Count)];
                }
                names.Add(temp);
            }

            File.WriteAllLines("taverns.txt", names);
            Console.WriteLine("Done!");
        }
    }
}

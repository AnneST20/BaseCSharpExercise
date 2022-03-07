using System;
using System.Collections.Generic;

namespace BaseCSharpExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextAnalizer analizer = new TextAnalizer();
            string[] lines = analizer.Lines;
            WordsSplitter wordsSplitter = new WordsSplitter(lines);
            SortedList<string, List<Occurence>> words = wordsSplitter.Words;

            Console.WriteLine();
            foreach (var word in words)
            {
                Console.Write("  < ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(word.Key);
                Console.ResetColor();
                Console.WriteLine(" > - {0} times", word.Value.Count);
            }

            Console.Write("\nPlease enter a word from the list: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ResetColor();

            while (!words.ContainsKey(input))
            {
                Console.Write("\nThere's no such word in the list. Try another word: ");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ResetColor();
            }

            List<Occurence> occurences = words[input];

            foreach (Occurence occurence in occurences)
            {
                Console.WriteLine("\tLine {0}, index {1}", occurence.Line, occurence.Index);
            }
        }
    }
}

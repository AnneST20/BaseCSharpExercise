using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCSharpExercise
{
    internal class WordsSplitter
    {
        string[] lines;
        SortedList<string, List<Occurence>> words;

        public SortedList<string, List<Occurence>> Words 
        { 
            get { return words; }
        }

        public WordsSplitter(string[] lines)
        {
            this.lines = lines;
            GetWords();
        }
        /// <summary>
        /// Splits all the words from array of lines into  a linked list
        /// </summary>
        void GetWords()
        {
            words = new SortedList<string, List<Occurence>>();
            int index = 0;
            int totalIndex = 0;
            string word = null;

            for(int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
            {
                int length = lines[lineNumber].Length;
                if (lines[lineNumber].Length > 0)
                {
                    int endIndex = 0;
                    int lineIndex = 0;
                    while (endIndex != -1)
                    {
                        word = LineReader(lines[lineNumber], out endIndex);
                        AddWord(word, lineNumber + 1, lineIndex + totalIndex);
                        index = endIndex + 1;
                        lineIndex += index;
                        lines[lineNumber] = lines[lineNumber].Substring(index);
                    }
                }
                totalIndex += length;
            }
        }
        /// <summary>
        /// Returns the next (or the last) word from the line
        /// </summary>
        /// <param name="line">String line from where we looking for next word</param>
        /// <param name="endIndex">The index of the end of the word</param>
        /// <returns></returns>
        string LineReader(string line, out int endIndex)
        {
            endIndex = line.IndexOf(" ");
            string word = null;

            if (endIndex != -1)
            {
                word = line.Substring(0, endIndex);
            }
            else
            {
                word = line;
            }

            return word;
        }
        /// <summary>
        /// A method that helps to add new words to the linked list (even if key exists)
        /// </summary>
        /// <param name="word"></param>
        /// <param name="line"></param>
        /// <param name="position"></param>
        void AddWord(string word, int line, int position)
        {
            if (words.ContainsKey(word))
            {
                List<Occurence> occurences = words[word];
                occurences.Add(new Occurence { Line = line, Index = position });
                words[word] = occurences;
            }
            else
            {
                List<Occurence> occurences = new List<Occurence>();
                occurences.Add(new Occurence { Line = line, Index = position });
                words.Add(word, occurences);
            }
        }
    }
}

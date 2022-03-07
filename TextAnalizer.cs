using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaseCSharpExercise
{
    internal class TextAnalizer
    {
        string path;
        string directory;
        string[] lines;
        string[] files;

        public string[] Lines
        {
            get { return lines; }
        }

        public TextAnalizer()
        {
            directory = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net5.0", "Texts\\");
            Print();
            do
            {
                GetPath();
                lines = GetLines(path);
            }
            while (lines == null);

            for(int i = 0; i < lines.Length; i++)
            {
                lines[i] = FormatText(lines[i]);
            }

            foreach (string line in lines)
            {
                File.WriteAllLines(path, lines);
            }
        }
        /// <summary>
        /// The method that print the greeting to the user writes the list of the text files in this projects
        /// </summary>
        void Print()
        {
            Console.WriteLine("Enter a path to the file or choose a number from the list:\n");
            files = Directory.GetFiles(directory);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"\t{i + 1} - {files[i].Replace(directory, "")}");
            }
        }
        /// <summary>
        /// The method that generates the full path to the selected file from the list or the path from input
        /// </summary>
        void GetPath()
        {
            if (path == null)
            {
                Console.Write("\nPath: ");
            }
            else
            {
                Console.Write("\nThere's no file with such path. Please enter path again: ");
            }
            path = Console.ReadLine();
            int num;

            if (Int32.TryParse(path, out num))
            {
                if (num > 0 && num < files.Length + 1)
                {
                    path = files[num - 1];
                }
            }
        }
        /// <summary>
        /// Returns array of lines from file
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns></returns>
        static string[] GetLines(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                return lines;
            }
            catch 
            { 
                return null; 
            }
        }
        /// <summary>
        /// Formatting text, deleting delimiters and double spaces
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        string FormatText(string line)
        {
            string[] delimeters = { ".", ",", "?", "!", "\"", " - ", ":", ":"};

            foreach(string s in delimeters)
            {
                line = line.Replace(s, " ");
            }

            while (line.Contains("  "))
            {
                line = line.Replace("  ", " ");
            }

            line = line.Trim();
            line = line.ToLower();

            return line;
        }
    }
}

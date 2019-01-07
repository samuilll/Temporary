using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryConsole.Exams;

namespace DictionaryConsole
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"All words in your dictionary: {new DbWords().Words.Count()}");

            Console.Write("Please choose how many questions you want to be asked for:");
            int howManyQuestions = int.Parse(Console.ReadLine());
            var exam = new ExamLastWords(howManyQuestions);

            //Console.WriteLine("Please choose first word number:");
            //int firstWordNumber = int.Parse(Console.ReadLine());
            //Console.WriteLine("Please choose last word number:");
            //int lastWordNumber = int.Parse(Console.ReadLine());
            //var exam = new ExamAllWords(firstWordNumber, lastWordNumber);

            exam.Run();
        }

        private static void SaveInFile()
        {
            List<Word> words = new DbWords().Words.ToList();
            List<string> lines = new List<string>();

            foreach (var word in words)
            {
                lines.Add(word.ToString());
            }

            File.WriteAllLines("../../wordsdata.txt", lines);
            Console.WriteLine();
        }
    }


}

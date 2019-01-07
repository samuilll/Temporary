using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConsole.Exams
{
    public abstract class Exam
    {

        protected Exam(int numberOfQuestions)
        {
            this.RightAnswers = 0;
            this.ByNowQuestions = 0;
            this.WordsAsList = new DbWords().Words.ToList();
            this.NumberOfQuestions = numberOfQuestions;
        }

        protected Exam(int firstWordNumber,int lastWordNumber)
        {
            this.RightAnswers = 0;
            this.ByNowQuestions = 0;
            this.WordsAsList = new DbWords().Words.ToList();
            this.NumberOfQuestions = lastWordNumber - firstWordNumber + 1;
            this.FirstWordNumbuer = firstWordNumber;
            this.LastWordNumbuer = lastWordNumber;
        }

        public List<Word> WordsAsList
        {
            get;
            protected set;
        }
        public int NumberOfQuestions { get; set; }
        public int FirstWordNumbuer { get;protected set; }

        public int LastWordNumbuer { get; protected set; }



        private int rightAnswers;
        public int RightAnswers
        {
            get { return rightAnswers; }
            protected set { rightAnswers = value; }
        }

        private int byNowQuestions;

        public int ByNowQuestions
        {
            get { return byNowQuestions; }
            protected set { byNowQuestions = value; }
        }

        protected void RecalculateAndPrintTheCurrentresult()
        {
            this.ByNowQuestions += 1;
            this.NumberOfQuestions--;
            Console.WriteLine($"Result:{RightAnswers}/{ByNowQuestions}");
            Console.WriteLine("Please push enter for the next question");
            Console.ReadKey();
            Console.WriteLine();
        }

        protected void AskOneQuestion(Word currentWord)
        {
            Console.WriteLine($"Meaning:\t{currentWord.Meaning}");
            Console.Write($"Answer:\t");

            var answer = Console.ReadLine();
            if (answer == currentWord.Text.Trim())
            {
                Console.WriteLine("CORRECT!");
                Console.WriteLine(currentWord);
                RightAnswers += 1;
            }
            else
            {
                Console.WriteLine("WRONG ANSWER!");
                Console.WriteLine(currentWord);
            }
        }

        protected double CalculateTheGrade()
        {
            double percent = ((double)this.RightAnswers / this.ByNowQuestions) * 100;

            return percent * 0.04 + 2;
        }
        protected List<Word> Randomize(List<Word> wordsAsList)
        {
            var rmz = new Random();

            for (var i = 0; i < wordsAsList.Count; i++)
            {
                var firstIndex = i;
                var secondIndex = rmz.Next(0, wordsAsList.Count);
                var firstWord = wordsAsList[firstIndex];
                wordsAsList[firstIndex] = wordsAsList[secondIndex];
                wordsAsList[secondIndex] = firstWord;
            }

            return wordsAsList;
        }

        public abstract void Run();

    }
}

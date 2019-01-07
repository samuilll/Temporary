using System;
using System.Collections.Generic;
using System.Linq;
using DictionaryConsole.Exams;

namespace DictionaryConsole
{
    public class ExamAllWords : Exam
    {
        public ExamAllWords(int numberOfQuestions) : base(numberOfQuestions)
        {
        }

        public ExamAllWords(int firstWordNumber, int lastWordNumber):base(firstWordNumber,lastWordNumber)
        {
        }

       
       

        public void PrintOnlyTheWords()
        {
            foreach (var word in WordsAsList) Console.Write($" {word.Text} ");
        }
     

        public override void Run()
        {
            var neededWords = this.WordsAsList.Skip(this.FirstWordNumbuer-1).Take(this.NumberOfQuestions).ToList();
            var words = new Queue<Word>(Randomize(neededWords));

            while (this.NumberOfQuestions > 0)
            {
                var currentWord = words.Dequeue();

                this.AskOneQuestion(currentWord);

                this.RecalculateAndPrintTheCurrentresult();
            }

            Console.WriteLine($"TOTAL RESULT: {RightAnswers}/{ByNowQuestions}");
            Console.WriteLine($"GRADE: {CalculateTheGrade():f2}");
        }

       
    }
}
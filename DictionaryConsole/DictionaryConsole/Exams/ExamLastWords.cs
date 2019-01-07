using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConsole.Exams
{
  public  class ExamLastWords:Exam
    {
        public ExamLastWords(int numberOfQuestions) : base(numberOfQuestions)
        {
        }

        public override void Run()
        {
            List<Word> words = Randomize(this.WordsAsList.Skip(this.WordsAsList.Count - this.NumberOfQuestions).ToList());

            while (this.NumberOfQuestions>0)
            {
                Word currentWord = words[0];

                words.RemoveAt(0);

                this.AskOneQuestion(currentWord);

                this.RecalculateAndPrintTheCurrentresult();
            }

            Console.WriteLine($"TOTAL RESULT: {RightAnswers}/{ByNowQuestions}");
            Console.WriteLine($"GRADE: {CalculateTheGrade():f2}");
        }
    }
}

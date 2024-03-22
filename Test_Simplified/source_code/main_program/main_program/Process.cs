using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace main_program
{
    class Process
    {
        public List<Question> ConvertedQuestions { get; set; } = new();

        public Process(IEnumerable<OpenXmlElement> rawOpenXmlElementList) 
        {
            CompleteQuestion question = new CompleteQuestion();
            foreach (var rawElement in rawOpenXmlElementList)
            {
                string innerText = rawElement.InnerText;

                if (rawElement.GetType().ToString().Contains("Table"))
                {
                    Console.WriteLine("Yes");
                    StringStoredAnswer convertAnswers = new StringStoredAnswer(innerText);
                    Console.WriteLine(convertAnswers.ToString());
                    continue;
                }

                //-------------------------------------------------------------------------

                if (innerText.StartsWith("Câu "))
                {
                    question = new();
                    question.AddMainQuestion(innerText.Trim());
                }
                else
                {
                    innerText = Regex.Replace(innerText, "[A-Z]\\.", "");
                    question.AddOptions(innerText.Trim());
                }

                if(question.MainQuestion is not null && question.GetLength() == 4)
                {
                    ConvertedQuestions.Add(question);
                }
            }
        }

        public void DisplayElement()
        {
            foreach (Question question in ConvertedQuestions)
            {
                Console.WriteLine(question.ToString());
            }
        }
    }
}
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace main_program
{
    class ConvertQuestions
    {
        public List<Question> ConvertedQuestions { get; set; } = new();

        public ConvertQuestions(IEnumerable<OpenXmlElement> rawOpenXmlElementList) 
        {
            Question question = new Question();
            bool shouldAdd = false;
            foreach (var rawElement in rawOpenXmlElementList)
            {
                string innerText = rawElement.InnerText;

                //Loại bỏ các phần tử không thuộc Tệp Trắc Nghiệm như: tiêu đề, mức độ, ...
                if (innerText.StartsWith("Câu 1")) shouldAdd = true;
                if (!shouldAdd || innerText == " ") continue;
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
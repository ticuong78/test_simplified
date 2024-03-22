using DocumentFormat.OpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_program
{
    class Question: Options
    {
        public string MainQuestion { get; set; }

        public Question() { }

        public Question(List<string> sentences)
        {
            if (!sentences[0].Contains("Câu")) throw new ArgumentException("Cannot find any question or the question is not at the first position of the list");
            MainQuestion = sentences[0];
            foreach(var item in sentences)
            {
                OptionsList.Add(item);
            }
        }

        public void AddMainQuestion(string question)
        {
            MainQuestion = question;
        }

        public override string ToString()
        {
            if(MainQuestion is null && OptionsList.Count != 4)
            {
                throw new ArgumentNullException("A question must has one main question and 4 options, please check good. Use AddMainQuestion or AddOption to fill in a Question instance");
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MainQuestion);
            foreach (var item in OptionsList)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
    }
}

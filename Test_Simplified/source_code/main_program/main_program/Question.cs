using DocumentFormat.OpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_program
{
    class Question: IEnumerable
    {
        public string MainQuestion { get; set; }
        public List<string> Options { get; set; } = new List<string>();

        public Question() { }

        /// <summary>
        /// Use to add the main question into the object if the object is created by using no-parameter constructor. Should be used along with AddOptions method, or you cannot use any further of its composite methods
        /// </summary>
        /// <param name="question"></param>
        public void AddMainQuestion(string question)
        {
            MainQuestion = question;
        }

        /// <summary>
        /// Should be use along with AddMainQuestion method, use AddMainQuestion method for how-to-use guide
        /// </summary>
        /// <param name="option"></param>
        public void AddOptions(string option)
        {
            if (option.Contains("   "))
            {
                string[] strings = option.Split("   ");
                foreach (string smallString in strings)
                {
                    Options.Add(smallString.Trim());
                }
            }
            else
                Options.Add(option);
        }

        public void AddOptions(List<string> options)
        {
            Options.AddRange(options);
        }

        public void AddOptions(string[] options)
        {
            Options.AddRange(options);
        }

        public Question(List<string> sentences)
        {
            if (!sentences[0].Contains("Câu")) throw new ArgumentException("Cannot find any question or the question is not at the first position of the list");
            MainQuestion = sentences[0];
            foreach(var item in sentences)
            {
                Options.Add(item);
            }
        }

        /// <summary>
        /// Return the total length of all object's composite elements, including the main question
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If there is no more than 2 options are passed in</exception>
        public int GetLength()
        {
            if (MainQuestion is null && Options.Count < 2) throw new ArgumentException("Main question and at least 2 options are required.");
            return Options.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MainQuestion);
            foreach (var item in Options)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Options).GetEnumerator();
        }
    }
}

using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_program
{
    class StringStoredAnswer
    {
        public string Answers {  get; set; }
        public StringStoredAnswer(string answers)
        {
            Answers = answers;
        }

        public override string ToString()
        {
            return Answers;
        }

        public List<char> ConvertAnswer()
        {
            List<char> temp = Answers.Split(".").Select((answer, index) => Convert.ToChar(answer)).ToList();
            return temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_program
{
    class CompleteQuestion: Question
    {
        public char Answer { get; set; }
        public CompleteQuestion(List<string> sentences, char answer): base(sentences)
        {
            Answer = answer;
        }

        public CompleteQuestion(List<string> sentences) : base(sentences) { }

        public CompleteQuestion() : base() { }

        public void AddAnswer (char answer)
        {
            Answer = answer;
        }
    }
}

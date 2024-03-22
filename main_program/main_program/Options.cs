using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_program
{
    abstract class Options
    {
        public List<string> OptionsList { get; set; } = new List<string>();
        public Options() { }

        public Options(List<string> optionsList) 
        {
            OptionsList = optionsList;
        }

        public int GetLength ()
        {
            return OptionsList.Count;
        }


        // Su dung de them option vao OptionList khi su dung constructor khong co param
        public void AddOptions(string option)
        {
            if (option.Contains("   "))
            {
                string[] strings = option.Split("   ");
                foreach (string smallString in strings)
                {
                    OptionsList.Add(smallString.Trim());
                }
            }
            else
                OptionsList.Add(option);
        }

        public void AddOptions(List<string> options)
        {
            OptionsList.AddRange(options);
        }

        public void AddOptions(string[] options)
        {
            OptionsList.AddRange(options);
        }
        //----------------------------------------------------------------------
    }
}

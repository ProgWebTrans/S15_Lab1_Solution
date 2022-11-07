using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PresseMots_Utility
{
    public  class WordCounter
    {
        public  int Count(string input) {

            string pattern = "[^\\w]";
            var wordCount = Regex.Split(input ?? String.Empty, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline).Where(s => !string.IsNullOrWhiteSpace(s)).Count();
            return wordCount;

        }

        public  int Count(IWordCountable wordCountable) {
            return Count(wordCountable.Content);
        }
            
            
            

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPracticeOf_C_Sharp.string_manipulation
{
    public class string_manipulation_code
    {
        public double StrLength(string str)
        {
            return str.Length;
        }
        public string StringReverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            return reversed;
        }
        public void String_Splitting_with_space(string sentence)
        {
            string[] words = sentence.Split(' ');
            Console.WriteLine("Words in the sentence:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
        public string String_Lowercase_Conversion(string sentence)
        {
            return sentence.ToLower();
        }
        public string String_Uppercase_Conversion(string sentence)
        {
            return sentence.ToUpper();
        }
        public string String_Concatenation(string str1, string str2)
        {
            string ConcatenatString = str1 + " " + str2;
            return ConcatenatString;
        }
        public bool String_Comparison(string str1, string str2)
        {
            bool isEqual = String.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
            return isEqual;
        }
        public void Character_Count(string sentence, char charToCount)
        {
            int count = 0;
            foreach (char c in sentence)
            {
                if (c == charToCount)
                {
                    count++;
                }
            }
            Console.WriteLine($"Number of '{charToCount}' in \"{sentence}\": {count}");
        }
        public string Substring_Extraction(string sentence,int start,int end)
        {
            string substring = sentence.Substring(start,end);
            return substring;
        }
    }
}

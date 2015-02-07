using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConsole
{
    public class Word
    {
        public string word { get; set; }
        public int length { get; set; }
        public char[] vowels { get; set; }
        public char[] letters { get; set; }
        public char firstLetter { get; set; }
        public char lastLetter { get; set; }

        public Word() { }

        public Word(string w) {
            this.word = w;
            this.length = w.Length;
            this.firstLetter = w[0];
            this.lastLetter = w[w.Length - 1];

            var _vowels = w.Where(a => a.Equals('a') || a.Equals('e') || a.Equals('i') || a.Equals('o') || a.Equals('u'));

            vowels = new char[_vowels.Count()];
            for (int i = 0; i < vowels.Length; i++)
            {
                vowels[i] = _vowels.ElementAt(i);
            }

            int countSpaces = w.Where(b => b.Equals(' ')).Count();
            int countApostrophe = w.Where(c => c.Equals(@"'")).Count();
            int countLetters = w.Length - (_vowels.Count() + countSpaces + countApostrophe);

            var _letters = w.Where(a => a != 'a' && a != 'e' && a != 'i' && a != 'o' && a != 'u');
            this.letters = new char[_letters.Count()];
            for (int j = 0; j < _letters.Count(); j++)
            {
                this.letters[j] = _letters.ElementAt(j);
            }

        }


        public string print() {
            return string.Format("Word: {0}\nLength: {1}\nFirst Letter: {2}\nLast Letter: {3}\nVowels: {4}\nLetters: {5}", 
                                this.word, this.length, this.firstLetter, this.lastLetter, getVowels(), getLetters());
        }

        private string getVowels() {
            string result = "";
            for (int i = 0; i < this.vowels.Length; i++)
            {
                result += vowels[i] + ",";
            }
            return result==""?"Word with 0 vowels":result.Substring(0, result.Length-1);
        }

        private string getLetters() {
            string result = "";
            for (int i = 0; i < this.letters.Length; i++)
            {
                result += letters[i] + ",";
            }
            return result==""?"Word with 0 letters":result.Substring(0, result.Length-1);
        }



    }
}

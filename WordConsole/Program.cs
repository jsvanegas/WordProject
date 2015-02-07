using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = File.ReadAllText("words.txt");
            string[] strWordsArray = words.Split(',');
            Word[] wordsArray = new Word[strWordsArray.Length];

            for (int i = 0; i < wordsArray.Length; i++)
            {
                wordsArray[i] = new Word(strWordsArray[i]);
            }

            bool again = true;
            while (again)
            {
                Console.WriteLine("\n---------------------------------\nWrite an index or word to search for");
                string q = Console.ReadLine();
                int index = 0;
                try
                {
                    Console.WriteLine(int.TryParse(q, out index) ? wordsArray[index].print() : wordsArray.Where(a => a.word.Equals(q)).Single().print());
                }
                catch (InvalidOperationException operationEx)
                {
                    Console.WriteLine("\n\tWord {0} not found!", q);
                }
                catch (IndexOutOfRangeException indexEx) {
                    Console.WriteLine("\n\tWord at index {0} not found!", index);                
                }
                
                Console.WriteLine("\n\n-----------------------------------------\n\nDo you want to continue? y/n");
                again = Console.ReadKey().KeyChar == 'y' ? true : false;
            }


        }
    }
}

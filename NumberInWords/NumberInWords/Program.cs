using System;
using System.IO;
using System.Linq;

namespace NumberInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ','};//, '.', ':'};
            EnglishWordifiedNumber numInWord = new EnglishWordifiedNumber();
            Console.WriteLine("Enter number of dollars which you want to convert to have it written in English");
            try
            {

                string number = Console.In.ReadLine();
                if (number == "0")
                {
                    Console.WriteLine("The number in currency fomat is \nZero Only");
                }
                else
                {
                    string[] words = number.Split(delimiterChars);
                    string output = "Output " + number + " is ";
                    output += numInWord.toWords(Int64.Parse(words[0]));
                    output +=  words[0] == "1" ? " dollar" : " dollars";
                    if (words.Length > 1)
                    {
                        output += " and ";
                        if (words[1].Length == 1)
                            words[1] += "0";
                        output += numInWord.toWords(Int64.Parse(words[1]));
                        output += words[1] == "01"  ? " cent" : " cents";

                    }
                    Console.WriteLine(output);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

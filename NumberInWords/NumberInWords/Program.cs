using System;
using System.IO;

namespace NumberInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            EnglishWordifiedNumber numInWord = new EnglishWordifiedNumber();
            TextReader tIn = Console.In;
            Console.WriteLine("Enter number of dollars which you want to convert to have it written in English");
            string number = tIn.ReadLine();
            Console.WriteLine("Output " + number + " is "+ numInWord.toWords(Int64.Parse(number)));
        }
    }
}

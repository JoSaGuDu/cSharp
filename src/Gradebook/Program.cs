using System;
using System.Collections.Generic;


namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)//Command line application entry point
        {
            var book = new Book("first gradebook");
            book.AddGrade(3.5);
            book.AddGrade(53.5);
            book.AddGrade(93.5);
            book.showStatistics();



            //using parameters passed from command line and the parametization syntax: '$'"Some text {variableName}""
            if (args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                Console.WriteLine("Hello Mr. NoValuePassed!");
            }
        }
    }
}

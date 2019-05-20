using System;
using System.Collections.Generic;


namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)//Command line application entry point
        {
            var book = new Book("first gradebook");
            //I need to ask the user for enter as many grades as he needs.
            var providing_grades = true;
            var grades = book.GetGrades();

            //using constant 
            Console.WriteLine("The curent gradebook is:");
            Console.WriteLine($"Gradebook name: {book.Name}");
            Console.WriteLine("The ISBN is: {Book.ISBN}");//Calling a CONSTANT (static member) with the ClassName.CONSTANT

            do
            {   
                Console.WriteLine("Do you want to enter a grade?(y/n)");
                var continuing = Console.ReadLine();

                switch (continuing)
                {   
                    case "n":
                        if (grades.Count > 0 ){
                            Console.WriteLine("It should print thestatistics");
                            book.showStatistics();
                        } else
                            {
                              Console.WriteLine("No grades in the book");  
                            }
                        Console.WriteLine("Press \"q\" anytime to quit");
                        break;
                    case "y":             
                        Console.WriteLine("Please enter a grade");
                        var grade = Console.ReadLine();
                        try 
                        {
                            book.AddGrade(double.Parse(grade));
                        }
                        /* catch(Exception ex)//Catch the specific exception you expect additionally to this generic exeption cath 
                        {
                            Console.WriteLine(ex.Message);
                        } Reemplaced by the specific catchers*/
                        catch(ArgumentException ex)//Catching the specific exception I spect
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(FormatException ex)//Catch the specific exception you expect additionally to this generic exeption cath 
                        {
                            Console.WriteLine(ex.Message);
                        }  
                        finally
                        {
                            //Write here any code to be exceuted always that the exception is trown.
                            Console.WriteLine("Finally, please try again!");
                            //close sockets...
                            //clean memory...
                        }
                        Console.WriteLine($"There are {grades.Count} grades in {book.Name}");
                        Console.WriteLine("Press \"q\" anytime to quit");
                        break;

                    case "q":
                        Console.WriteLine("Exit program... bye!");
                        providing_grades = false;
                        break;

                    default:
                        Console.WriteLine("Press \"y\" to enter a grade");
                        Console.WriteLine("Press \"n\" to see the report");
                        Console.WriteLine("Press \"q\" anytime to quit");
                        break;   
                }
                
                Console.WriteLine($"Can you providing grades? {providing_grades}");
            } while (providing_grades);

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

using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        //class constructor. Constructors can be overloaded.
        public Book(string name)
        {
            //this.name = name;//using this explicity to avoid name=name
            Name = name;//Changed into public property so is Capitalized and dont need the use of this to diferentiate from name
            grades = new List<double>();//initilaization
            high_grade = double.MinValue;//representes the smallest positive double aviable. primer value. Also Math.Max(num, reference) can be used
            low_grade = double.MaxValue;
            category = "Design"; //Can be seted and modified only inside a constructor
        }

        //Behavior-methods
        public void AddGrade(double grade)
        {   
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)//if is null means nobody is listening to this event
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                Console.WriteLine("Invalid Grade");//replaced by the exception management.
                throw new ArgumentException($"Invalid argument for {nameof(grade)}");
            }
        }
        public void AddGrade(char letterGrade)//Overloaded method with different signature but same name
        {
            switch (letterGrade)
            {
                case 'A'://Be sure using single quotes for char. Otherwise it will be compiled as a string.
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(90);
                    break;
                case 'C':
                    AddGrade(90);
                    break;
                case 'D':
                    AddGrade(90);
                    break;
                case 'F':
                    AddGrade(90);
                    break;
                default:
                    Console.WriteLine("Letter grades are one of those: A, B, C, D, or F. Please, check the grade and enter a valid letter grade.");
                break;    
            }
        }
        //I need to compute the statistics
        public double CalculateAvg()
        {
            var result = 0.0;

            foreach (double grade in grades)
            {
                result += grade;
            }
            result /= grades.Count;
            return Math.Floor(result * 100) / 100;
        }
        public double CalcHigherGrade()
        {
            foreach (double grade in grades)
                {
                    if (grade >= high_grade)
                    {
                        high_grade = grade;
                    }
                }

            return high_grade;
        }
        public double CalclowGrade()
        {
            foreach (double grade in grades)
            {
                if (grade <= low_grade)
                {
                    low_grade = grade;
                }
            }

            return low_grade;
        }

        public char CalcLetterGrade(double grade)
        {
            switch (grade)
            {
                case var g when g >= 90.0: 
                    letter_grade = 'A';
                    break;

                case var g when g >= 80.0: 
                    letter_grade = 'B';
                    break;

                case var g when g >= 70.0: 
                    letter_grade = 'C';
                    break;

                case var g when g >= 60.0: 
                    letter_grade = 'D';
                    break;

                case var g when g < 60.0: 
                    letter_grade = 'F';
                    break;

                default:
                    Console.WriteLine("Letter AVG cant be calculated. Check input");
                break;    
            }
            return letter_grade;
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = this.CalculateAvg();
            result.HigherGrade = this.CalcHigherGrade();
            result.LowerGrade = this.CalclowGrade();
            result.LetterAVG = this.CalcLetterGrade(result.Average);
            return result;
        }
        public void showStatistics()
        {
            var stats = GetStatistics();
            Console.WriteLine($"The AVG grade is: {stats.Average:N2}");//result:Nx is formating the value result to display on digit presicsion.
            Console.WriteLine($"The Higher grade is: {stats.HigherGrade:N2}");
            Console.WriteLine($"The Lower grade is: {stats.LowerGrade:N2}");
            Console.WriteLine($"The AVG lettre grade is: {stats.LetterAVG}");
        }
        //I need to retrieve the grades
        public List<double> GetGrades()
        {
            return grades;
        }
        //State / fields: don't admint implicit typing var varName = new typeName<type>()
        private List<double> grades;//definition
        public double high_grade;
        public double low_grade;
        public char letter_grade;
       // private string name;//backing field for the name property
        public string Name { get; set; } //name AUTO-property(Interface for a private field)
        public readonly string category;//Only modified inside a constructor
        public const string ISBN = "7006GFDY8HHf653KJ7D";//Constant inmutable during objects lifetime. They are considered static members so outside the class you have to call the with:  ClassNAme.CONSTNAME

        //Adding event listeners
        public event GradeAddedDelegate GradeAdded;//Definig a delegated field of type GradeAddedDelegate
    }
}
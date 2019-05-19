using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
    {
        //class constructor
        public Book(string name)
        {
            //this.name = name;//using this explicity to avoid name=name
            Name = name;//Changed into public property so is Capitalized and dont need the use of this to diferentiate from name
            grades = new List<double>();//initilaization
            high_grade = double.MinValue;//representes the smallest positive double aviable. primer value. Also Math.Max(num, reference) can be used
            low_grade = double.MaxValue;
        }

        //Behavior-methods
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
            grades.Add(grade);
            }
            else {
                Console.WriteLine("Invalid Grade");
            }
        }

        public void AddGradeLetter(char letterGrade)
        {
            switch (letterGrade)
            {
                case 'A':
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
        public double CalculateAvg
        {
            get
            {
                var result = 0.0;

                foreach (double grade in grades)
                {
                    result += grade;
                }
                result /= grades.Count;
                return Math.Floor(result * 100) / 100;
            }
        }
        public double CalcHigherGrade
        {
            get
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
        }
        public double CalclowGrade
        {
            get
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
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = this.CalculateAvg;
            result.HigherGrade = this.CalcHigherGrade;
            result.LowerGrade = this.CalclowGrade;
            return result;
        }
        public void showStatistics()
        {
            var stats = GetStatistics();
            Console.WriteLine($"The AVG grade is: {stats.Average:N2}");//result:Nx is formating the value result to display on digit presicsion.
            Console.WriteLine($"The Higher grade is: {stats.HigherGrade:N2}");
            Console.WriteLine($"The Lower grade is: {stats.LowerGrade:N2}");
        }
        //I need to retrieve the grades
        public List<double> GetGrades()
        {
            return grades;
        }
        //State-fields: don't admint implicit typing var varName = new typeName<type>()
        private List<double> grades;//definition
        public string Name;
        public double high_grade;
        public double low_grade;
    }
}
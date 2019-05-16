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
            Name = name;//Changed into public property so is Capitalized and dont need the use of this to diferentite from name
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

        //I need to expose the statistics
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

        //State-fields: don't admint implicit typing var varName = new typeName<type>()
        private List<double> grades;//definition
        public string Name;
        public double high_grade;
        public double low_grade;
    }
}
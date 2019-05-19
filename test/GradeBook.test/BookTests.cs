using System;
using System.Collections.Generic;
using Xunit;

//remember to add references if the class is in a different project: dotnet add reference ../path/to/external/prjectName.csproj
//remember to add using statements if the test is in a different name space of the units to be tested

namespace Gradebook.test
{
    public class BookTests
    {
        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void BookCalculatesStatistics()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            //I need an instance of the class I want to test
            var book = new Book("");
            book.AddGrade(3.5);
            book.AddGrade(53.5);
            book.AddGrade(93.5);

            //act section: perform the unit to be tested
            var result = book.GetStatistics();
            //assert section: perform the actual test
            Assert.Equal(93.5, result.HigherGrade);
            Assert.Equal(3.5, result.LowerGrade);
            Assert.Equal(50.16, result.Average, 2);
            Assert.Equal('F',result.LetterAVG);

        }

        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void GradeIsInRange()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            //I need an instance of the class I want to test
            var book = new Book("");
            
            //act section: perform the unit to be tested
            book.AddGrade(105);
            List<double> result = book.GetGrades();
            //assert section: perform the actual test
           Assert.True(result.Count == 0);
        }
    }
}
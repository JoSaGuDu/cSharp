using System;
using Xunit;

//remember to add references if the class is in a different project: dotnet add reference ../path/to/external/prjectName.csproj
//remember to add using statements if the test is in a different name space of the units to be tested

namespace Gradebook.test
{
    public class TypeTests
    {
        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void GetBoooksReturnsDifferentObjects()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            //I need an instance of the class I want to test


            //act section: perform the unit to be tested

            //assert section: perform the actual test
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);//or
            Assert.NotSame(book1, book2);
        }

        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void CSharpPassByValue()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New name");

            //I need an instance of the class I want to test


            //act section: perform the unit to be tested

            //assert section: perform the actual test
            Assert.Equal("Book1", book1.Name);
        }

        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void CSharpCanPassByReference()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            var book1 = GetBook("Book1");
            GetBookSetNameByRef(ref book1, "New name");//or GetBookSetNameByRef(out book1, "New name");

            //I need an instance of the class I want to test


            //act section: perform the unit to be tested

            //assert section: perform the actual test
            Assert.Equal("New name", book1.Name);
        }

        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void CanSetPropertyFromReference()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            var book1 = GetBook("Book1");
            SetName(book1, "New name");

            //I need an instance of the class I want to test


            //act section: perform the unit to be tested

            //assert section: perform the actual test
            Assert.Equal("New name", book1.Name);
        }

        [Fact]//attribute that decorates the methods that actually will be invoked in the test.
        public void TwoVariablesCanReferenceSameObject()//use expicit names
        {
            //arange section: declare and arrange all data required for the test
            var book1 = GetBook("Book1");
            var book2 = book1;
            //I need an instance of the class I want to test


            //act section: perform the unit to be tested

            //assert section: perform the actual test
            Assert.Same(book1, book2);//or
            Assert.True(Object.ReferenceEquals(book1, book2));
        }



        Book GetBook(string bookName)
        {
            return new Book(bookName);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetNameByRef(ref Book book, string name)//or GetBookSetNameByRef(out book1, "New name");
        {
            book = new Book(name);//This is mandatory if use out
        }



    }
}

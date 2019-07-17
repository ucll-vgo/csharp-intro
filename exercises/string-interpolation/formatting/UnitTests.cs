using System;
using Xunit;

namespace Exercise
{
    public class UnitTests
    {
        [Fact]
        public void FormattingGreetingJohn()
        {
            const string name = "John";
            const string expected = "Hello, John";
            var actual = Formatter.Greet(name);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormattingGreetingAnne()
        {
            const string name = "Anne";
            const string expected = "Hello, Anne";
            var actual = Formatter.Greet(name);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormattingDate()
        {
            const int day = 1;
            const int month = 4;
            const int year = 1999;
            const string expected = "01/04/1999";
            var actual = Formatter.FormatDate(day, month, year);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormattingDate2()
        {
            const int day = 10;
            const int month = 12;
            const int year = 2011;
            const string expected = "10/12/2011";
            var actual = Formatter.FormatDate(day, month, year);

            Assert.Equal(expected, actual);
        }
    }
}

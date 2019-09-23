using System;
using Xunit;

namespace FractionExercise
{
    public class UnitTests
    {
        [Fact]
        public void Addition1()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            var expected = new Fraction(3, 4);
            var actual = a + b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Addition2()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 2);
            var expected = new Fraction(1, 1);
            var actual = a + b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Addition3()
        {
            var a = new Fraction(-1, 2);
            var b = new Fraction(-1, 4);
            var expected = new Fraction(-3, 4);
            var actual = a + b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Addition4()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(-1, 4);
            var expected = new Fraction(1, 4);
            var actual = a + b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Addition5()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, -4);
            var expected = new Fraction(1, 4);
            var actual = a + b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Negation()
        {
            var a = new Fraction(1, 2);
            var expected = new Fraction(-1, 2);
            var actual = -a;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Negation2()
        {
            var a = new Fraction(1, -2);
            var expected = new Fraction(1, 2);
            var actual = -a;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtraction()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            var expected = new Fraction(1, 4);
            var actual = a - b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiplication1()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(1, 4);
            var expected = new Fraction(1, 8);
            var actual = a * b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiplication2()
        {
            var a = new Fraction(3, 5);
            var b = new Fraction(2, 7);
            var expected = new Fraction(6, 35);
            var actual = a * b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiplication3()
        {
            var a = new Fraction(5, 7);
            var b = new Fraction(7, 5);
            var expected = new Fraction(1, 1);
            var actual = a * b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Division()
        {
            var a = new Fraction(5, 9);
            var b = new Fraction(5, 3);
            var expected = new Fraction(1, 3);
            var actual = a / b;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Comparison()
        {
            var a = new Fraction(1, 5);
            var b = new Fraction(1, 5);
            var c = new Fraction(1, 7);
            var d = new Fraction(5, 1);

            Assert.True(a == b);
            Assert.False(a != b);

            Assert.False(a == c);
            Assert.True(a != c);

            Assert.False(a == d);
            Assert.True(a != d);
        }
    }
}

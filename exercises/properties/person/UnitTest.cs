using System;
using Xunit;

namespace Exercise
{
    public class UnitTests
    {
        [Fact]
        public void ValidPersonCreation()
        {
            const string name = "John";
            const int age = 19;
            var person = new Person(name, age);

            Assert.Equal(name, person.Name);
            Assert.Equal(age, person.Age);
        }

        [Fact]
        public void InvalidPersonCreation_NullName()
        {
            const string name = null;
            const int age = 19;

            Assert.Throws<ArgumentException>(() => new Person(name, age));
        }

        [Fact]
        public void InvalidPersonCreation_EmptyName()
        {
            const string name = "";
            const int age = 19;

            Assert.Throws<ArgumentException>(() => new Person(name, age));
        }

        [Fact]
        public void InvalidPersonCreation_WhitespaceName()
        {
            const string name = "     ";
            const int age = 19;

            Assert.Throws<ArgumentException>(() => new Person(name, age));
        }

        [Fact]
        public void InvalidPersonCreation_NegativeAge()
        {
            const string name = "Emma";
            const int age = -2;

            Assert.Throws<ArgumentException>(() => new Person(name, age));
        }

        [Fact]
        public void SettingName()
        {
            const string originalName = "Tophie";
            const string newName = "Sophie";
            const int age = 52;

            var person = new Person(originalName, age);
            Assert.Equal(originalName, person.Name);
            person.Name = newName;
            Assert.Equal(newName, person.Name);
        }

        [Fact]
        public void SettingAge()
        {
            const string name = "John";
            const int originalAge = 19;
            const int newAge = originalAge + 1;
            var person = new Person(name, originalAge);

            Assert.Equal(originalAge, person.Age);
            person.Age = newAge;
            Assert.Equal(newAge, person.Age);
        }

        [Fact]
        public void SettingInvalidAge()
        {
            const string name = "Peter";
            const int age = 75;
            var person = new Person(name, age);

            Assert.Throws<ArgumentException>(() => { person.Age = -1; });
        }

        [Fact]
        public void SettingInvalidName_Null()
        {
            const string name = "Peter";
            const int age = 11;
            var person = new Person(name, age);

            Assert.Throws<ArgumentException>(() => { person.Name = null; });
        }

        [Fact]
        public void SettingInvalidName_Empty()
        {
            const string name = "Peter";
            const int age = 11;
            var person = new Person(name, age);

            Assert.Throws<ArgumentException>(() => { person.Name = ""; });
        }

        [Fact]
        public void SettingInvalidName_Whitespace()
        {
            const string name = "Peter";
            const int age = 11;
            var person = new Person(name, age);

            Assert.Throws<ArgumentException>(() => { person.Name = "        "; });
        }
    }
}

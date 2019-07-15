using System;

namespace Solution
{
    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if ( string.IsNullOrWhiteSpace(value) )
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if ( value < 0 )
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.age = value;
                }
            }
        }
    }
}
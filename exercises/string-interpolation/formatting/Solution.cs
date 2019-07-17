using System;

namespace Solution
{
    public static class Formatter
    {
        public static string Greet(string name) => $"Hello, {name}";

        public static string FormatDate(int day, int month, int year) => $"{day:00}/{month:00}/{year}";
    }
}
using System;

namespace Solution
{
    public class Time
    {
        private const int MinutesPerHour = 60;

        private const int SecondsPerMinute = 60;

        public Time(int hours, int minutes, int seconds)
        {
            TotalSeconds = hours * MinutesPerHour * SecondsPerMinute + minutes * SecondsPerMinute + seconds;
        }

        public int TotalSeconds { get; }

        public int Seconds => TotalSeconds % SecondsPerMinute;

        public int Minutes => (TotalSeconds / SecondsPerMinute) % MinutesPerHour;

        public int Hours => TotalSeconds / MinutesPerHour / SecondsPerMinute;
    }
}
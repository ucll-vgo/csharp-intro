using System;
using Exercise;

namespace Solution
{
    public class Clock
    {
        private int totalSeconds;

        private const int SecondsPerMinute = 60;

        private const int SecondsPerHour = 60 * 60;

        private const int SecondsPerDay = 60 * 60 * 24;

        public Clock(ITimerService timer)
        {
            timer.Tick += this.OnTick;
        }

        private void OnTick()
        {
            totalSeconds++;

            NotifyObservers();
        }

        private void NotifyObservers()
        {
            NotifySecondObservers();
            NotifyMinuteObservers();
            NotifyHourObservers();
            NotifyDayObservers();
        }

        private void NotifySecondObservers()
        {
            SecondPassed?.Invoke(totalSeconds);
        }

        private void NotifyMinuteObservers()
        {
            if ( totalSeconds % SecondsPerMinute == 0 )
            {
                MinutePassed?.Invoke(totalSeconds / SecondsPerMinute);
            }
        }

        private void NotifyHourObservers()
        {
            if ( totalSeconds % SecondsPerHour == 0 )
            {
                HourPassed?.Invoke(totalSeconds / SecondsPerHour);
            }
        }

        private void NotifyDayObservers()
        {
            if ( totalSeconds % SecondsPerDay == 0 )
            {
                DayPassed?.Invoke(totalSeconds / SecondsPerDay);
            }
        }

        public event Action<int> SecondPassed;

        public event Action<int> MinutePassed;

        public event Action<int> HourPassed;

        public event Action<int> DayPassed;
    }
}

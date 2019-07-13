using System;
using System.Collections.Generic;
using Xunit;

namespace Exercise
{
    public class UnitTests
    {
        private MockTimerService timerService = new MockTimerService();

        [Fact]
        public void TestSeconds()
        {
            var clock = new Clock(timerService);
            var data = new List<int>();

            clock.SecondPassed += data.Add;

            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(1);
            Assert.Equal( new List<int> { 1 }, data );
            timerService.GenerateTicks(4);
            Assert.Equal( new List<int> { 1, 2, 3, 4, 5 }, data );
        }

        [Fact]
        public void TestMinutes()
        {
            var clock = new Clock(timerService);
            var data = new List<int>();

            clock.MinutePassed += data.Add;

            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(59);
            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(1);
            Assert.Equal( new List<int> { 1 }, data );
            timerService.GenerateTicks(40);
            Assert.Equal( new List<int> { 1 }, data );
            timerService.GenerateTicks(265);
            Assert.Equal( new List<int> { 1, 2, 3, 4, 5, 6 }, data );
        }

        [Fact]
        public void TestHours()
        {
            var clock = new Clock(timerService);
            var data = new List<int>();

            clock.HourPassed += data.Add;

            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(2 * 60 * 60 - 1);
            Assert.Equal( new List<int> { 1 }, data );
            timerService.GenerateTicks(1);
            Assert.Equal( new List<int> { 1, 2 }, data );
        }

        [Fact]
        public void TestDays()
        {
            var clock = new Clock(timerService);
            var data = new List<int>();

            clock.DayPassed += data.Add;

            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(60 * 60 * 24 - 1);
            Assert.Equal( new List<int> { }, data );
            timerService.GenerateTicks(60 * 60 * 24);
            Assert.Equal( new List<int> { 1 }, data );
            timerService.GenerateTicks(1);
            Assert.Equal( new List<int> { 1, 2 }, data );
        }
    }

    public class MockTimerService : ITimerService
    {
        public event Action Tick;

        public void GenerateTicks(int n)
        {
            if ( Tick != null )
            {
                while ( n-- > 0 ) Tick();
            }
        }
    }
}

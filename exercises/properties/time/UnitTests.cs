using System;
using Xunit;

namespace Exercise
{
    public class UnitTests
    {
        [Fact]
        public void Time_0_0_0()
        {
            var time = new Time(0, 0, 0);

            Assert.Equal(0, time.TotalSeconds);
            Assert.Equal(0, time.Seconds);
            Assert.Equal(0, time.Minutes);
            Assert.Equal(0, time.Hours);
        }

        [Fact]
        public void Time_0_0_1()
        {
            var time = new Time(0, 0, 1);

            Assert.Equal(1, time.TotalSeconds);
            Assert.Equal(1, time.Seconds);
            Assert.Equal(0, time.Minutes);
            Assert.Equal(0, time.Hours);
        }

        [Fact]
        public void Time_0_0_2()
        {
            var time = new Time(0, 0, 2);

            Assert.Equal(2, time.TotalSeconds);
            Assert.Equal(2, time.Seconds);
            Assert.Equal(0, time.Minutes);
            Assert.Equal(0, time.Hours);
        }

        [Fact]
        public void Time_0_1_0()
        {
            var time = new Time(0, 1, 0);

            Assert.Equal(60, time.TotalSeconds);
            Assert.Equal(0, time.Seconds);
            Assert.Equal(1, time.Minutes);
            Assert.Equal(0, time.Hours);
        }

        [Fact]
        public void Time_0_2_0()
        {
            var time = new Time(0, 2, 0);

            Assert.Equal(120, time.TotalSeconds);
            Assert.Equal(0, time.Seconds);
            Assert.Equal(2, time.Minutes);
            Assert.Equal(0, time.Hours);
        }

        [Fact]
        public void Time_1_0_0()
        {
            var time = new Time(1, 0, 0);

            Assert.Equal(3600, time.TotalSeconds);
            Assert.Equal(0, time.Seconds);
            Assert.Equal(0, time.Minutes);
            Assert.Equal(1, time.Hours);
        }

        [Fact]
        public void Time_2_0_0()
        {
            var time = new Time(2, 0, 0);

            Assert.Equal(7200, time.TotalSeconds);
            Assert.Equal(0, time.Seconds);
            Assert.Equal(0, time.Minutes);
            Assert.Equal(2, time.Hours);
        }

        [Fact]
        public void Time_1_2_3()
        {
            var time = new Time(1, 2, 3);

            Assert.Equal(3600 + 120 + 3, time.TotalSeconds);
            Assert.Equal(3, time.Seconds);
            Assert.Equal(2, time.Minutes);
            Assert.Equal(1, time.Hours);
        }
    }
}

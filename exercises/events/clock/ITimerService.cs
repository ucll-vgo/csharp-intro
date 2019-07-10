using System;

namespace ClockExercise
{
    public interface ITimerService
    {
        event Action Tick;
    }
}
using System;

namespace Exercise
{
    public interface ITimerService
    {
        event Action Tick;
    }
}
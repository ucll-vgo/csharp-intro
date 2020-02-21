# Assignment

You are writing an application where some actions need
to be taken at regular intervals: some should
take place every second, others every minute, hour or day.
You decide to introduce a class `Clock` that provides
four events:

* `SecondPassed`
* `MinutePassed`
* `HourPassed`
* `DayPassed`

Functions registered with these events get called
every second, minute, hour or day, respectively.
For example,

```csharp
var clock = new Clock();

clock.SecondPassed += (n) => Console.WriteLine("A second passed!");
clock.MinutePassed += (n) => Console.WriteLine("A minute passed!");
```

Each observer function receives a parameter of type `int` (called `n` in the above code).
This indicates how many seconds/minutes/... have passed.
The first time a function is called, `n` will be set to `1`, the next time it will
be `2`, etc.

Now, how does `Clock` know how much time has passed? For this,
it relies on a service provided by the OS, which is
here represented as `ITimerService`:

```csharp
public interface ITimerService
{
    event Action Tick;
}
```

The `Tick` event gets raised once a second. In other words:

* The `SecondPassed` event should be raised each time `Tick` occurs.
* The `MinutePassed` event should be raised after every 60 `Tick`s.
* The `HourPassed` event should be raised after every 60 &times; 60 `Tick`s.
* The `DayPassed` event should be raised after every 60 &times; 60 &times; 24 `Tick`s.

`Clock` receives the `ITimerService` object through its constructor.

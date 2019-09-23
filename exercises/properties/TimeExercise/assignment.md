# Assignment

Write a `Time` class that represents a time duration in hours, minutes and seconds. The class should have the following members:

* A constructor that takes `hours`, `minutes` and `seconds`. There are no limitations on the values.
* A property `TotalSeconds` that equals the total number of seconds, i.e., hours, minutes and seconds have to be converted into seconds and summated.
* A property `Seconds` equaling the seconds component of the duration. It is always a value between `0` and `59`.
* A property `Minutes` equaling the minutes component of the duration. It is always a value between `0` and `59`.
* A property `Hours` equaling the hours component of the duration. There is no bound on it.

## Example

```csharp
var time = new Time(1, 0, 5); // 1 hour, 0 minutes, 5 seconds

Console.WriteLine($"Total seconds: {time.TotalSeconds}");
Console.WriteLine($"Seconds: {time.Seconds}");
Console.WriteLine($"Minutes: {time.Minutes}");
Console.WriteLine($"Hours: {time.Hours}");
```

should print

```text
Total seconds: 3605
Seconds: 5
Minutes: 0
Hours: 1
```

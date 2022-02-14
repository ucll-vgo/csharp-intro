# Assignment

## Opening the Exercise

Make sure you have opened the exercise correctly.
In the Solution Explorer (typically on the right of your screen), you should see

* Solution 'FormattingExercise'
  * FormattingExercise
    * Dependencies
    * assignment.md
    * Solution.cs
    * UnitTests.cs

If you see a list of exercises, something went wrong.
Check the instructions on the [main page](https://github.com/ucll-vgo/csharp-intro) to learn how to open the exercises in Visual Studio correctly.

## Solving the Exercise

Write a class `Formatter` with the following members:

* `Greet(string name)` that returns the string `"Hello, name"` where `name` is replaced
  by the given name.
* `FormatDate(int day, int month, int year)` that produces the string `"day/month/year"`.
  The day and month part must be exactly two wide, using `0` as padding. For example,
  `FormatDate(1, 1, 1)` should return `01/01/1`. Note: this functionality is built-in,
  so look online for how to do it.

To add a new file, you can right click on the FormattingExercise project in the Solution Explorer, pick Add -> New Item.
Ctrl-Shift-A will also to do the trick.

To run the tests, right click on `UnitTests.cs` and select Run Tests.

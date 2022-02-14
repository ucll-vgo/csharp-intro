# Assignment

## Opening the Exercise

First, make sure you opened the exercise the correct way.
In the "Solution Explorer" (typically on the right), you should see the following structure:

* Solution FormattingExercise
  * FormattingExercise
    * assignment.md
    * Solution.cs
    * UnitTests.cs

If, however, you have a list of all exercises in the repository, something went wrong.
You can either open the exercise using File Explorer, by double clicking on the FormattingExercise.sln.
Or, you can open it from within Visual Studio: in the menu File -> Open -> Project/Solution and select FormattingExercise.sln. 

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

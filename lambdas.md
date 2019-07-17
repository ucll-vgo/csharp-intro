---
layout: default
---
# Lambdas

## Citizenship

You've probably heard of variables, those nifty little
things that let you store all kinds of values in them,
such as `int`s, or `double`s, or `bool`s, or even `string`s!

Not everything can be stored in a variable, though.
For example, you cannot assign a type to a variable:

```csharp
var t = int; // Does not compile
```

There exist languages that allow you to do this,
but Java or C# aren't one of those languages.
In other words, what can be stored in a variable depends
on the language. Things that can be stored in a variable
are called *first-class citizens*, while
those things that cannot are called *third-class citizens*.
(There's of course also *second-class citizens*, but
we ignore those since they don't matter for the discussion at hand.)

Let's focus now on functions (or methods.) Can we assign them to variables?

```csharp
char GetCharAt(string str, int index) { ... }

var func = GetCharAt; // Does this work?
```

In older versions of Java (pre 1.8), this was disallowed.
However, C# and Java 1.8+ do allow this kind of assignment.
This raises the question, what should be the type of `func`?

In Java, this is a bit complicated, so we'll only preoccupy ourselves
with C#. In C#, `func` has type `Func<string, int, char>`:

* The *last* type parameter represents the function's return type.
* All other type parameters correspond to the parameter types of the function.

In other words, a function

```csharp
R func(T1 x1, T2 x2, ..., Tn xn) { }
```

can be stored in a variable with the following type:

```csharp
Func<T1, T2, ..., Tn, R> f = func;
```

## Example Usage: Sorting

Being able to store functions in variables means you can
also pass them along as arguments. There are many uses
for this.

Sorting a list of values is a common thing to do, but generally,
you want to be able to specify how the values should ultimately be ordered.
Say you have a list of `Person`s, do you want them ordered
by weight, by name, by height, or by some other criterion?

Functions are a perfect candidate to represent this order:

```csharp
void Sort(List<Person>, Func<Person, Person, bool> shouldBeLeftOf)
```

Here, `isLessThan` is a function that is able to compare two `Person`
objects and say which belongs to the left of the other.

```csharp
bool OrderByName(Person p1, Person p2)
{
    return p1.Name < p2.Name;
}

bool OrderByHeight(Person p1, Person p2)
{
    return p1.Height < p2.Height;
}

bool OrderByAge(Person p1, Person p2)
{
    return p1.Age < p2.Age;
}

List<Person> people;
Sort(people, OrderByName); // Sort list by name
Sort(people, OrderByAge); // Sort list by age
```

We can generalize the `Sort` function so as to be able to work
with values of any type:

```csharp
void Sort<T>(List<T> xs, Func<T, T, bool> leftOf) { ... }
```

Similarly, we can define `Minimum` and `Maximum` functions
that accept such a function. This would allow
us to find the youngest person (`Minimum(people, OrderByAge)`)
or the tallest one (`Maximum(people, OrderByHeight)`).

A function accepting another function as a parameter
is called a *higher-order function*.
The flexibility they offer allow algorithms to be very widely applicable.
While in practice you won't often write higher-order functions yourself,
you'll probably want to make use of libraries of such functions.

## Lambda Expressions

A lambda expression (often just called "lambda")
is nothing more than an anonymous function.

Say you want to order your `List<Person>` by bmi.
For this, you'll need a new function `OrderByBMI`:

```csharp
bool OrderByBMI(Person p1, Person p2)
{
    return p1.BMI < p2.BMI;
}

void SomeOtherMethod()
{
    Sort(people, OrderByBMI);
}
```

Having to define a new method is a bit cumbersome and
pollutes your class: after a while, you'll have
plenty of single use helper methods
meant to be used in conjunction with some
higher order function.

Instead, you can keep the function's definition
to where it's actually needed:

```csharp
void SomeOtherMethod()
{
    Sort(people, OrderByBMI);

    bool OrderByBMI(Person p1, Person p2)
    {
        return p1.BMI < p2.BMI;
    }
}
```

This function-in-a-function is called a *local function*,
which have been introduced in C# 7.0. Making use of
local functions keeps your class clean.

However, it's still syntactically heavy.
This is where lambdas shine:

```csharp
void SomeOtherMethod()
{
    Sort(people, (p1, p2) => p1.bBMI < p2.BMI);
}
```

Here, `(p1, p2) => p1.bBMI < p2.BMI` is the lambda.
It defines a function that takes two parameters
`p1` and `p2` and returns `p1.bBMI < p2.BMI`.
In other words, you can write the entire function on the same line
as where you need it.

Lambdas are anonymous functions, meaning you don't need to find a name for the function.
You also don't need to specify any types:
parameter types and return type are [inferred](type-inference.md) by the compiler.

## Further Reading

* [Lambda expressions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions)
* [Local functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions)

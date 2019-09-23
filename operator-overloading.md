---
layout: default
---
# Operator Overloading

Consider Java's `+` operator. It has multiple meanings:

* You can use it to add `int`s together. Similarly for `double`, `float`, `short`, etc.
* You can concatenate `String`s.

However, you cannot use `+` on any other value. For example, take
the `BigInteger` class that model integers of arbitrary size.

```java
BigInteger i1 = new BigInteger("48716153125384908304114345890938590");
BigInteger i2 = new BigInteger("4731894798759870245032740982745987179847");

BigInteger i3 = i1.add(i2);
```

Without being able to use `+` or any other of the arithmetic operators,
working with `BigInteger`s quickly becomes hard to read.
Likewise for other mathematical concepts such as fractions, vectors, matrices, etc.

Many other languages (such as C++, Python, Ruby and C#) do allow
the user to define new meaning for `+` (and other operators) for
their own classes. For example,

```csharp
class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public int Numerator { get; }
    public int Denominator { get; }

    public static Fraction operator *(Fraction left, Fraction right)
    {
        return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator)
    }

    public static Fraction operator +(Fraction left, Fraction right) { ... }
    public static Fraction operator -(Fraction left, Fraction right) { ... }
    public static Fraction operator /(Fraction left, Fraction right) { ... }
}

// Usage:
var x = new Fraction(1, 2);
var y = new Fraction(3, 4);
var z = x * y; // equals 3/8
```

## Equality

In many languages, there are two types of equality:

* Reference equality
* Value equality

In Java, `==` checks for reference equality: `x == y` means "do
`x` and `y` refer to the *same* object?", whereas
`x.equals(y)` denotes value equality, meaning "do the object model the same value?"
This has as consequence that, while `==` is by
far the most intuitive and concise notation, it is
rarely the equality you need.

C# prefers to associate the shorter notation for the more frequently used operation.
Given that value equality is what is needed most, it makes
sense to represent it using `==`.

Operator overloading makes this possible: a class
can redefine what it means to compare objects
using `==`. The most prominent example of this
is `string`: whereas Java requires you to rely
on `equals` to compare `String`s, C#
lets you use `==`, since it has been redefined
to call `Equals`.

```csharp
string s1, s2;

var b1 = s1.Equals(s2);
var b2 = s1 == s2;

// b1 will always equal b2 (on strings!)
```

## Exercises

Exercises can be found on the `master` branch.

* `exercises/operator-overloading/FractionExercise`

## Further Reading

* [Official Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading)

---
layout: default
---
# Properties

This section is particularly important, as properties
are ubiquitous in C# code.

## Getters and Setters

Consider the following class in Java:

```java
// Java
public class Counter
{
    public int currentValue;

    public Counter()
    {
        this.currentValue = 0;
    }
}
```

Using this class is quite straightforward:

```java
// Java
var counter = new Counter();

counter.currentValue++;
```

Now imagine the `Counter` class needs to be extended with extra functionality, such as

* Forbidding negative values
* Being observable, i.e., send notifications whenever the `currentValue` changes

To implement this functionality, `Counter` needs to know *when* `currentValue` is changed.
In its current state, this is impossible: everyone has direct access to `currentValue`
and `Counter` cannot intercept changes made to this field.

The standard solution to this problem is to introduce a getter and a setter:

```java
// Java
public class Counter
{
    private int currentValue;

    public Counter()
    {
        this.currentValue = 0;
    }

    public int getCurrentValue()
    {
        return currentValue;
    }

    public void setCurrentValue(int newValue)
    {
        this.currentValue = newValue;
    }
}
```

Now that `currentValue` is private, the only way to change its
value is to go through `setCurrentValue`. Now `Counter`
has full control over `currentValue`: if someone needs
to happen each time `currentValue` changes, such as validation
or notification, it can add this code to `setCurrentValue`. Problem solved.

Ideally, we would be able to start with the simple implementation
(public field, no getter/setter) and, whenever the need arises,
move to the more complex implementation (private field, getter/setter).
However, making this change invalidates all client code:
all direct references to `currentValue` must be replaced
with a call to the getter or setter:

```java
counter.currentValue++;

// must be changed to

counter.setCurrentValue( counter.getCurrentValue() + 1 );
```

This is unacceptable: a change internal to `Counter` should
never impact client code. To prevent such a change from ever
being necessary, Java's solution is to skip the
simple implementation and go straight to the getter/setter variant.
Even if, at the moment of creation, a public field suffices,
you can never know what the future will bring, and anticipating
possible modifications, you need to preventively "overengineer" your class
by adding a getter and a setter. This way, whatever
updates need to be made to `Counter`, all client code can remain the same.

## C#'s Solution

C# wants you to be able to start off with the easy notation, namely that
of a public field:

```csharp
// C#
public class Counter
{
    public Counter()
    {
        this.CurrentValue = 0;
    }

    public int CurrentValue;
}

// Usage
var counter = new Counter();
counter.CurrentValue++;
```

Now comes the issue of having to add extra logic: `Counter` must somehow know
whenever `CurrentValue` is modified. In Java, the only option is to introduce
methods which regulate access to `CurrentValue`. C#, however,
allows you to add a getter and setter without having
to give up the regular field access syntax.

```csharp
// C#
public class Counter
{
    public Counter()
    {
        this.CurrentValue = 0;
    }

    // Backing field
    private int currentValue;

    public int CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
        }
    }
}

// Usage
var counter = new Counter();
counter.CurrentValue++;
```

Here, `CurrentValue` is known as a *property*. Basically,
it's a "intelligent field".

* `currentValue` acts as the "backing field", that is, the actual
  variable which stores the value.
* The getter (`get { ... }`) simply returns the backing field's value.
* The setter (`set { ... }`) assigns the new value to the backing field.
  Note the variable `value`: it is a "magic variable" like `this`.
  `value` is only available inside setters and contains the value
  that is being assigned to `CurrentValue`.

Notice how the client code has remained unchanged.
`counter.CurrentValue++` causes the following steps to be taken:

* First, it is translated to `counter.CurrentValue = counter.CurrentValue + 1` (the astute
  reader might object and complain this is not an accurate translation; this is true,
  but we prefer to focus on the essence.)
* Next, `counter.CurrentValue` in the right hand side is evaluated: it
  intends to read `CurrentValue`'s value. This is done by calling the getter,
  which simply returns the backing field `currentValue`'s value.
  In our case, this value equals `0`.
* Then, one is added to this result, which gives us `1`.
* Lastly, this new value needs to be assigned to `CurrentValue`. This is done
  by calling the setter for which `value` will be set to `1`.

In other words, in C#, innocuous looking code like `obj.field = 5`
could actually cause a lot of code to be executed. The assignment operator
is not "just assignment" anymore.

As an example, let's add validation. Say negative values should be prohibited:

```csharp
// C#
public class Counter
{
    public Counter()
    {
        this.CurrentValue = 0;
    }

    // Backing field
    private int currentValue;

    public int CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if ( value < 0 )
            {
                throw new ArgumentException("Cannot assign negative values to CurrentValue");
            }
            currentValue = value;
        }
    }
}
```

The code shown below will throw an exception, due to the `=` operator
calling the setter, which checks that `value` (here equal to `-1`) is positive.

```csharp
var counter = new Counter();
counter.CurrentValue = -1;
```

## Shorter Syntax

To be perfectly honest, even in C#, it's better to start off with a
property instead of a public field. (Cake point for those who can tell us why.)
In code:

```csharp
public class Counter
{
    // Backing field
    private int currentValue;

    public int CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
        }
    }
}
```

Now C# has lost its edge over Java: you still need to write
a whole bunch of code just to get`CurrentValue` working.
So, we need the following pieces of code:

* A backing field (here `currentValue`)
* A property with
  * a getter that simply returns the backing field's value
  * a setter that stores `value` in the backing field

This pattern occurs often, often enough so that C#
has introduced a shortened syntax:

```csharp
public class Counter
{
    public int CurrentValue { get; set; }
}
```

This code is equivalent with the preceding example:
the compiler generates a backing field, a getter and a setter for you.
The backing field is now hidden: you cannot access it directly anymore;
instead, you'll need to go through `CurrentValue`.

This way, C# regains its advantage: you can start off with simple code
and, if need be, extend it without the client noticing.
In short, the rules are

* Simple things require simple code
* Moving to more complex functionality can happen gradually, without
  having to break client code.

## No Setter

Often, you'll want to omit the setter: it's often not as useful as
you'd think. You can simply leave it out:

```csharp
public class Foo
{
    public int SomeProperty { get; }
}
```

Now you might wonder how this can possibly be useful: without
access to the backing field, how would you be able
to specify a value for `SomeProperty` other than its type's default value (here `0`)?

The above code does generate a setter, but it's only available
to the constructor. Thus, the following code is valid:

```csharp
public class Foo
{
    public Foo(int x)
    {
        this.SomeProperty = x;
    }

    public int SomeProperty { get; }
}

var foo = new Foo(5);
var x = foo.SomeProperty; // x is now 5
```

## Expression-Bodied Members

Consider the following code:

```csharp
public class Person
{
    public Person(DateTime dateOfBirth)
    {
        this.DateOfBirth = dateOfBirth;
    }

    public DateTime DateOfBirth { get; set; }

    public int Age
    {
        get
        {
            return (int) (DateTime.Now - this.DateOfBirth).TotalYears;
        }
    }
}
```

It is rather common for a getter to consist of a sole `return` statement,
as is the case for `Age`. Here too, C# offers a shortened syntax:

```csharp
public class Person
{
    public Person(DateTime dateOfBirth)
    {
        this.DateOfBirth = dateOfBirth;
    }

    public DateTime DateOfBirth { get; set; }

    public int Age => (int) (DateTime.Now - this.DateOfBirth).TotalYears;
}
```

The same is possible for methods.

## Extra Information

* [Properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
* [Expression-bodied members](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)

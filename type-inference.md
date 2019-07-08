---
layout: default
---
# Type Inference

Since Java 10, type inference is not exclusive to C# anymore.
We include this section anyway, since it is possible
you are not familiar with the topic at hand.

Type inference refers to the compiler's ability to infer (deduce) types
from the surrounding code. Some languages (such as Haskell)
have very powerful type inference: without any kind of type annotation
the compiler is able to examine your code as a whole and infer the
type for each variable. Unfortunately, such is not the case for
C# or Java: for technical reasons, type inference is very limited,
but it can still help make your code much more readable in certain
circumstances.

## Local variables

Consider the C# code below:

```csharp
List<int> ns = new List<int>();
```

The type `List<int>` occurs twice, which does not add anything to
type safety. For this reason, C# (and Java 10) allow you to write

```csharp
var ns = new List<int>();
```

No type information is lost: the compiler is able to *infer* that
`ns` is meant to have type `List<int>`. In other words,
there is no difference whatsoever between the two pieces
of code above, except for the fact that the latter is shorter.
Similarly for:

```csharp
var k = 5;         // same as int k = 5;
var s = "hello";   // same as string s = "hello";

double Foo() { ... }
var x = Foo();     // same as double x = Foo();
```

`var` can also be used inside `foreach` loops:

```csharp
var list = new List<SomeTypeWithALongName>();

foreach ( var item in list )
{
    // ...
}
```

The compiler infers that `item`'s type is `SomeTypeWithALongName`.

Type inference generally only works if all the necessary typing
information resides on the same line as the `var`. For example,

```csharp
var x;
x = 0;
```

While it would be reasonable to assume the compiler is able to
find out `x` is an `int`, this is not the case: `x` being
an `int` follows from the `x = 0` assignment, but because
it is located in a separate statement, the compiler does not "see" it
and will therefore not be able to infer `x`'s type. To make
the code compile, you need to explicitly mention `x`'s type:

```csharp
int x;
x = 0;
```

Similarly, the code below does not compile:

```csharp
var x = null;
```

`null` is a valid value for all reference types:
it could be a `string`, a `List<int>`, a `Person`, etc.
which means the compiler has insufficient information
to infer `x`'s type.

## Lambdas

Type inference as shown above might fail to impress,
and rightly so. However, type inference greatly improves
the readability of [lambdas](lambdas.md).

## More Information

* [JDK Enhancement Proposal](https://openjdk.java.net/jeps/286)

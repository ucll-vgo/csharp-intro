# Assignment

You are given a class `Fraction`, which the methods:

* `Add`
* `Negate`
* `Subtract`
* `Multiply`
* `Divide`

We want to replace them by operators, so that instead
of writing

```csharp
a.Multiply(b).Add(c).Negate()
```

we can write

```csharp
-(a * b + c)
```

Note that `Negate` and `Subtract` correspond to unary `-` and binary `-`, respectively.
For example, `a.Negate()` should be written `-a`, whereas `a.Subtract(b)`
should be denoted by `a - b`.

Also add definitions for `==` and `!=`; they should simply delegate to `Equals`.

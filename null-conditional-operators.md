---
layout: default
---
# Null-Conditional Operators

`null` can be quite a nuisance: each time
you receive an object, you're technically
supposed to check for `null`.
C# has added some operators that alleviate
the syntactic burden `null` imposes on you.

## Member Access

Consider the code below:

```csharp
if ( someObject != null )
{
    someObject.someAction();
}
```

This can be replaced by

```csharp
someObject?.someAction();
```

The `?.` operator first checks if `someObject` is `null`,
and only if that is not the case, the method `someAction` will be called.

In case `someAction` returns a value:

```csharp
var result = someObject?.someAction();
```

`result` will contain `null` if `someObject` is `null`, otherwise
it will be set to `someAction`'s return value. If necessary,
the return type is made [nullable](nullable-types.md), e.g., `int` is upgraded to `int?`
in order to `null` values.

## Indexing

C# offers a similar constructor for indexing:

```csharp
if ( someContainer != null )
{
    var element = someContainer[i];
}
```

can be replaced by

```csharp
var element = someContainer?[i];
```

Here, `element` will be assigned `null` if `someContainer` is `null`.

## Null Coalescing Operator

Say you have an object `x` which you don't want to be `null`.
If it is, you'd like this `null` to be replaced by some default value:

```csharp
x != null ? x : defaultValue
```

C# provides the null coalescing operator to shorten the syntax:

```csharp
x ?? defaultValue
```

For example, this can come in handy to remove the "nullability" from value types:

```csharp
void Foo(int? x)
{
    int y = x ?? 0; // Either use x, or 0 if x is null
}
```

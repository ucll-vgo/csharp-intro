---
layout: default
---
# Nullable Types

There are two kinds of types:

* Value types such as `int`, `double` and `bool`.
* Reference types such as `string` and `List<int>`. All classes define reference types.

Reference types can be set to `null`, but value types can't:

```csharp
int x = null;    // Error
```

Sometimes, however, the ability to set value types to `null`
can come in handy. In Java, in order to have a "nullable `int`",
you would use an `Integer`. C# instead offers nullable types:
simply add `?` to a value type. For example,

```csharp
int? x = null;
```

## See Also

* [Null-conditional operators](null-conditional-operators.md)

---
layout: default
---
# String Interpolation

Say you want to construct a string
`"Player N is the winner with K points"` where
`N` and `K` need to be replaced with values
stored in variables.
The manual way to go about it is to use addition:

```csharp
var message = "Player " + winner + " is the winner with " + scores[winner] + " points.";
```

A clearer and more efficient approach would be to use *string interpolation*:

```csharp
var message = $"Player {winner} is the winner with {scores[winner]} points.";
```

To indicate your intention to insert variables into the string,
you need to prefix the string literal with a `$`.
Inserting variable values can then be inserted using `{expression}`.

## Further Reading

* [Official documentation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)
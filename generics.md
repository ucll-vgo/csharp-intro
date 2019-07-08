---
layout: default
---
# Generics

In Java, generics only work on reference types. For example,
`ArrayList<int>` is invalid: you should use
`ArrayList<Integer>` instead.

C# has no such limitation: generics work with any type.
E.g., `List<int>` is perfectly valid. Consequently,
C# has no need for wrapper types such as `Integer`, `Double` or `Boolean`.
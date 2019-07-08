---
layout: default
---
# Common Types

Some common types are named differently in C# than in Java.

| Java name | C# name | Notes |
|-|-|-|
| `boolean` | `bool` | C# uses a shorter name |
| `String` | `string` | While `String` also works in C#, `string` is preferred |
| `ArrayList<T>` | `List<T>` | |
| `List<T>` | `IList<T>` | Interfaces for lists |
| `HashMap<K, V>` | `Dictionary<K, V>` | |
| `Map<K, V>` | `IDictionary<K, V>` | Interfaces for maps/dictionaries |

Note that `List<T>` is class implementing the interface `IList<T>` and
`Dictionary<K, V>` implements `IDictionary<K, V>`.

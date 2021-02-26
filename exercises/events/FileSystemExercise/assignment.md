# Assignment

Some applications are interested in being notified of any changes
done to the file system. For example, when opening a folder,
Visual Studio Code provides an up to date view
of its contents. Whenever someone adds or removes a file,
this view has to be updated to reflect this change.

OSses let you "observe" the file system, i.e.
you can ask it to call a certain function/method
whenever something happens. In this exercise,
the file system is represented by an object
implementing the `IFileSystem` interface:

```csharp
public interface IFileSystem
{
    event Action<string> FileCreated;

    event Action<string> FileWritten;

    event Action<string> FileDeleted;
}
```

This interface provides three events to which you can subscribe.
`Action<string>` string represents the type of the function
that can be subscribed: it is a function that receives a single
`string` parameter and with return type `void`. The parameter
represents the name of the file being created/written/deleted.

For example, to output a message each time a file has been created,
we first write a function:

```csharp
void OnFileCreated(string filename)
{
    Console.WriteLine($"{filename} has been created!");
}
```

Notice how its signature matches `Action<string>`: `string` parameter type,
`void` return type. Next, we can request this function be called
whenever a file is created:

```csharp
IFileSystem fs = GetFileSystem();
fs.FileCreated += OnFileCreated;
```

This will cause `XXX has been created!` to be printed whenever
a file `XXX` has been created.

## Your Task

Write a class `ChangedFilesCounter` that, given an `IFileSystem` via its constructor,
checks how many files undergo changes (created, modified or deleted).
This count should be accessible through a `ChangeCount` property.

For example, say I instantiate a `ChangedFilesCounter` as follows:

```csharp
var cfc = new ChangedFilesCounter(fileSystem);
```

Say the following changes are then made:

* `a.txt` is created.
* `b.txt` is deleted.
* `a.txt` is modified.

Reading `cfc.ChangeCount` should yield `2`, as two distinct files have undergone changes.
